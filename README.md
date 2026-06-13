# FactoryIQ Agent

**AI-powered Manufacturing Incident Intelligence using Microsoft IQ**

FactoryIQ Agent is a Microsoft Agents League Hackathon enterprise agent solution for investigating manufacturing incidents. It demonstrates multi-agent collaboration, a Microsoft IQ-ready intelligence layer, Azure OpenAI/Semantic Kernel integration seams, professional Fluent UI, OpenAPI, Docker, Bicep, CI, sample data, and responsible AI outputs.

## Quick Start

```bash
docker compose up --build
```

Open `http://localhost:5173` and run the Wafer Inspection Tool Failure demo.

## Configuration

Optional live AI settings:

```bash
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_DEPLOYMENT=gpt-4o
AZURE_OPENAI_API_KEY=
AZURE_TENANT_ID=
AZURE_CLIENT_ID=
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
