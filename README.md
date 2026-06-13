# FactoryIQ Agent

**AI-powered Manufacturing Incident Intelligence using Microsoft IQ**

FactoryIQ Agent is a Microsoft Agents League Hackathon enterprise agent solution for investigating manufacturing incidents. It demonstrates multi-agent collaboration, a Microsoft IQ-ready intelligence layer, Azure OpenAI/Semantic Kernel integration seams, professional Fluent UI, OpenAPI, Docker, Bicep, CI, sample data, and responsible AI outputs.

## Quick Start

```bash
docker compose up --build
```

Open `http://localhost:5173` and run the Wafer Inspection Tool Failure demo.

## Local Development

Backend:

```bash
dotnet restore FactoryIQ.sln
dotnet run --project src/FactoryIQ.Api/FactoryIQ.Api.csproj
```

Frontend:

```bash
cd frontend
npm install
npm run dev
```

When running outside Docker, the frontend proxy defaults to `http://localhost:8080`. Under Docker Compose, `VITE_API_PROXY_TARGET` is set to `http://api:8080`.

## Configuration

Optional live AI settings:

```bash
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_DEPLOYMENT=gpt-4o
AZURE_OPENAI_API_KEY=
AZURE_TENANT_ID=
AZURE_CLIENT_ID=
VITE_API_PROXY_TARGET=http://localhost:8080
```

The app also runs entirely with bundled sample data and a Microsoft IQ-compatible local provider.

## Projects

- `src/FactoryIQ.Api` - .NET 8 Web API with OpenAPI.
- `src/FactoryIQ.Core` - contracts and domain DTOs.
- `src/FactoryIQ.Agents` - four-agent workflow and Microsoft IQ abstraction.
- `src/FactoryIQ.Tests` - xUnit tests.
- `frontend` - React TypeScript Fluent UI application.

## Demo Scenario

Wafer Inspection Tool Failure with CPU spike, memory pressure, database latency, and recent deployment. The expected output includes root cause, confidence score, recommended actions, intelligence sources, agent contributions, and an executive report.

## Runnability Audit

See `docs/RepositoryAudit.md` for a static review of missing implementations, compilation risks, dependency gaps, configuration issues, runtime risks, placeholder/demo-grade files, and recommended fixes.
