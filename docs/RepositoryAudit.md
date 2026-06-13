# Repository Runnability Audit

This audit reviews the repository statically without depending on local execution. It covers source code, package references, Docker files, build scripts, environment variables, configuration files, missing implementations, compilation risks, runtime risks, and placeholder-like files.

## Executive Conclusion

The repository is a useful hackathon scaffold, but it is **not yet a production-complete runnable product**. It can become runnable in a correctly provisioned developer environment after dependency restore, but it still contains demo-grade implementations and several integration seams. The most important build/runtime blockers found in the static review were fixed in this pass: frontend TypeScript type dependencies, Docker/Vite API proxy configuration, the incomplete solution file, and explicit OpenAPI package support.

## Static Review Findings and Fixes

| Area | Finding | Risk | Fix Applied |
| --- | --- | --- | --- |
| Solution file | Earlier solution metadata was incomplete. | `dotnet restore FactoryIQ.sln` / IDE loading could fail. | Replaced with a full solution referencing all four backend projects. |
| API package references | `Program.cs` uses `.WithOpenApi()`. | Depending on SDK/package resolution, OpenAPI metadata extension may be missing. | Added `Microsoft.AspNetCore.OpenApi` to `FactoryIQ.Api.csproj`. |
| Frontend TypeScript dependencies | React TypeScript projects need React/DOM type packages. | `tsc -b` can fail with missing declaration files for `react` and `react-dom`. | Added `@types/react`, `@types/react-dom`, and `@types/node`. |
| Frontend/API connectivity | Vite proxy originally targeted only Docker service DNS. | Local `npm run dev` could fail because `api` is not resolvable outside Compose. | Added `VITE_API_PROXY_TARGET`, defaulting to `http://localhost:8080`, and Compose sets it to `http://api:8080`. |
| Docker Compose | Compose used compact syntax and lacked explicit API/frontend environment. | Harder to diagnose and less clear for local demo. | Expanded Compose with explicit ports and environment variables. |
| Project files | Several `.csproj` files were minified onto one line. | Maintainer readability risk; not a compilation blocker. | Reformatted backend project files. |

## Missing Implementations

1. **Live Azure OpenAI execution is not implemented.** The solution references Semantic Kernel and documents Azure OpenAI variables, but agents currently return deterministic DTOs from local code.
2. **Real Microsoft IQ API integration is not implemented.** This is intentional because the project does not assume a stable public .NET Microsoft IQ SDK. The `IIQProvider` abstraction isolates the integration point.
3. **Microsoft Entra ID authentication is not enforced.** `Microsoft.Identity.Web` is referenced, but the API currently allows anonymous calls for demo simplicity.
4. **Azure AI Search is not provisioned or queried.** Documentation mentions it as an enterprise deployment target, but no API code depends on it.
5. **Coverage reporting is not configured.** Tests exist, but no coverage collector or threshold enforcement is configured.

## Compilation Risks

1. **NuGet package versions require restore validation.** Package versions are plausible but should be restored in CI or a developer machine.
2. **Semantic Kernel version compatibility should be validated.** The package is referenced but not actively used in code, reducing immediate compile risk.
3. **C# collection expressions require .NET 8/C# 12.** This is consistent with the target framework, but older SDKs will fail.
4. **Frontend build requires npm registry access.** Without registry access, `npm install` cannot fetch Fluent UI/Vite/React dependencies.

## Missing Dependencies

1. The frontend previously lacked TypeScript declarations for React and Node/Vite config. These have been added.
2. The API previously did not explicitly reference `Microsoft.AspNetCore.OpenApi`; this has been added.
3. A `package-lock.json` is not committed. This means npm installs are not fully reproducible yet.

## Configuration Issues

1. **No committed `.env.example`.** Developers must infer variables from docs. Add one before final submission.
2. **No production frontend hosting configuration.** The frontend Dockerfile runs Vite dev server, which is acceptable for hackathon demos but not production hosting.
3. **CORS is permissive.** This is convenient for demos but should be restricted for enterprise deployment.
4. **Authentication configuration is absent.** Entra ID variables are documented but not wired into middleware or authorization policies.

## Runtime Risks

1. **API result is deterministic.** It demonstrates the workflow but not real LLM reasoning.
2. **Frontend assumes the analysis response shape is successful.** Error UI exists only as browser/default behavior; a production app should render API failures explicitly.
3. **Docker build depends on external package registries.** Offline Docker builds will fail without cached NuGet/npm dependencies.
4. **No health-based readiness dependency.** `depends_on` starts web after API container creation, not after API readiness.
5. **No persistence.** Uploaded incidents are not saved.

## Placeholder or Demo-Grade Files

These files are intentionally demo-grade and should be replaced or expanded before production use:

- `src/FactoryIQ.Agents/Prompts/*.prompt.md`: minimal prompt contracts, not production prompts.
- `src/FactoryIQ.Agents/IQProviders.cs`: bundled local provider, not a real Microsoft IQ connector.
- `infra/main.bicep`: minimal App Service baseline, not a complete secure Azure environment.
- `docs/*.md`: concise hackathon documentation, not exhaustive operations documentation.
- `artifacts/sample-workflow-result.json`: generated validation artifact, not live runtime output.

## Recommended Next Fixes

1. Add `.env.example` for API and frontend variables.
2. Add API error responses and frontend error rendering.
3. Wire optional Azure OpenAI/Semantic Kernel execution behind configuration while preserving offline demo mode.
4. Add Entra ID authentication in a clearly documented optional mode.
5. Add `package-lock.json` from a successful npm install in an environment with registry access.
6. Add GitHub Actions test, frontend build, and optional coverage publishing.
7. Replace Vite dev-server Docker hosting with production static asset hosting for non-demo deployments.
