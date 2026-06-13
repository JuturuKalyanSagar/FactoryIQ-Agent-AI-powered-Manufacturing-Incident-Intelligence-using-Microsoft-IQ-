# FactoryIQ Agent Architecture

FactoryIQ Agent is a clean, moderate-complexity enterprise agent system for manufacturing incident intelligence. It uses a .NET 8 API, four strongly typed agent services, a Microsoft IQ abstraction layer, and a React TypeScript Fluent UI frontend.

## Component Design
- **FactoryIQ.Api**: Minimal API, OpenAPI, dependency injection, CORS, health checks, incident analysis endpoint.
- **FactoryIQ.Core**: Data contracts and interfaces shared by the API and agents.
- **FactoryIQ.Agents**: Incident Intake, Intelligence, Root Cause, and Executive Report agents. Each agent emits JSON DTOs only.
- **FactoryIQ.Tests**: xUnit workflow coverage.
- **frontend**: Dashboard, Incident Analysis, Intelligence Center, and Executive Report sections.

## Microsoft IQ Integration Review
Research on June 13, 2026 found Microsoft IQ positioned as a unified enterprise intelligence layer with Work IQ, Fabric IQ, Foundry IQ, and Web IQ. Foundry IQ is documented as a managed knowledge layer; Work IQ tooling is preview-oriented and permission-aware. Because a stable general-purpose .NET Microsoft IQ SDK is not assumed, FactoryIQ isolates integration behind `IIQProvider`, `IQProviderFactory`, `IQResult`, `IQSource`, and `IQCitation`.

## Risks and Mitigations
- **Preview/changing IQ APIs**: contained behind `IIQProvider`.
- **Demo reliability**: bundled sample IQ provider enables offline demos.
- **Responsible AI**: confidence, citations, agent contributions, and non-authoritative recommendations are visible.
