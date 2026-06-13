# Runtime Validation

## Environment Used

Validation was attempted in the provided non-interactive container on June 13, 2026.

## Commands Attempted

| Command | Result | Notes |
| --- | --- | --- |
| `npm view vite version` | Failed | The configured npm registry returned `403 Forbidden`, preventing dependency installation. |
| `cd frontend && npm install && npm run build` | Failed | The same registry policy blocked `@fluentui/react-components`. |
| `dotnet build src/FactoryIQ.Api/FactoryIQ.Api.csproj` | Failed | The container does not have the .NET SDK installed. |
| `docker --version` | Failed | Docker is not installed in the container. |
| `node scripts-validate-e2e.mjs` | Passed | Validated bundled sample data and generated a representative workflow artifact without external dependencies. |

## Runtime Errors Documented

1. **Missing .NET SDK**: `/bin/bash: line 1: dotnet: command not found`.
2. **Missing Docker CLI/daemon**: `/bin/bash: line 1: docker: command not found`.
3. **Blocked npm registry access**: `403 Forbidden - GET https://registry.npmjs.org/@fluentui%2freact-components`.

## Fixes Applied After Validation

- Replaced the incomplete solution file with a full Visual Studio solution referencing all four backend projects.
- Added `Microsoft.AspNetCore.OpenApi` so the minimal API `WithOpenApi()` extension is explicit.
- Added `frontend/vite.config.ts` with a development proxy from the Vite frontend to the API container.
- Added `scripts-validate-e2e.mjs` to validate sample workflow data in environments where .NET, Docker, or npm registry access is unavailable.

## Local End-to-End Run Instructions

### Prerequisites

- .NET 8 SDK
- Node.js 22 or later
- Docker Desktop or Docker Engine with Compose
- Network access to NuGet and npm registries

### Option A: Docker Compose Demo

```bash
docker compose up --build
```

Open `http://localhost:5173`, then click **Run multi-agent analysis**.

### Option B: Local Developer Demo

Terminal 1:

```bash
dotnet restore FactoryIQ.sln
dotnet run --project src/FactoryIQ.Api/FactoryIQ.Api.csproj
```

Terminal 2:

```bash
cd frontend
npm install
npm run dev
```

Open `http://localhost:5173`, then click **Run multi-agent analysis**.

### Validate API Directly

```bash
curl -X POST http://localhost:8080/api/incidents/analyze \
  -H "Content-Type: application/json" \
  -d '{"title":"Wafer Inspection Tool Failure","description":"CPU spike, memory pressure, database latency after deployment","logs":["cpu spike 96%","memory pressure 91%","sql latency 850ms","deployment CHG-2026-0612"],"telemetry":{"cpu":96,"memory":91,"databaseLatency":850},"occurredAt":"2026-06-13T00:00:00Z","severity":"High"}'
```

Expected response includes `agentContributions`, `findings`, `rootCauses`, `report`, and Microsoft IQ intelligence sources.

### Fallback Validation Without External Dependencies

```bash
node scripts-validate-e2e.mjs
```

This writes `artifacts/sample-workflow-result.json` and verifies that bundled sample data supports the expected four-agent demo workflow.

## Screenshots

Screenshots require a running browser-accessible frontend. They could not be captured in this container because dependency installation and application startup were blocked by the environment limitations listed above. After running locally, capture:

1. Dashboard with **Powered by Microsoft IQ** badge.
2. Agent activity timeline.
3. Confidence and root cause card.
4. Intelligence source citations.
5. Executive report page/state.
