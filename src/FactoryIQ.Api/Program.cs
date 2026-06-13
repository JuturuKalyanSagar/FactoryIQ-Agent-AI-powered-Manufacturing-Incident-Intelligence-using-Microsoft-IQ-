using FactoryIQ.Agents; using FactoryIQ.Core.Contracts; using FactoryIQ.Core.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer(); builder.Services.AddSwaggerGen(); builder.Services.AddCors(o=>o.AddDefaultPolicy(p=>p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddSingleton<IIQProvider, BundledSampleIQProvider>(); builder.Services.AddSingleton<IIncidentIntakeAgent, IncidentIntakeAgent>(); builder.Services.AddSingleton<IIntelligenceAgent, IntelligenceAgent>(); builder.Services.AddSingleton<IRootCauseAgent, RootCauseAgent>(); builder.Services.AddSingleton<IExecutiveReportAgent, ExecutiveReportAgent>(); builder.Services.AddSingleton<IIncidentAnalysisOrchestrator, IncidentAnalysisOrchestrator>();
var app=builder.Build(); app.UseCors(); app.UseSwagger(); app.UseSwaggerUI();
app.MapGet("/health",()=>Results.Ok(new{status="healthy",poweredBy="Microsoft IQ"}));
app.MapPost("/api/incidents/analyze", async (IncidentInput input, IIncidentAnalysisOrchestrator orchestrator, CancellationToken ct)=> Results.Ok(await orchestrator.AnalyzeAsync(input, ct))).WithOpenApi();
app.Run();
