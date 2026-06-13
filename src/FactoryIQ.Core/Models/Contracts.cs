namespace FactoryIQ.Core.Models;

public sealed record IncidentInput(string Title, string Description, string[] Logs, Dictionary<string,double> Telemetry, DateTimeOffset OccurredAt, string Severity);
public sealed record NormalizedIncident(string IncidentId, string Title, string[] Symptoms, string[] Entities, Dictionary<string,double> Telemetry, string Severity);
public sealed record IQCitation(string Title, string Uri, string SourceType);
public sealed record IQSource(string Name, string Kind, string TrustLevel);
public sealed record IQResult(string Query, string Summary, IReadOnlyList<IQSource> Sources, IReadOnlyList<IQCitation> Citations, double RelevanceScore);
public sealed record IntelligenceFinding(string Finding, double Confidence, IReadOnlyList<IQResult> Evidence);
public sealed record RootCauseHypothesis(string Cause, double Confidence, string Rationale, string[] RecommendedActions);
public sealed record AgentContribution(string AgentName, string Summary, double Confidence);
public sealed record ExecutiveReport(string ExecutiveSummary, string TechnicalSummary, string[] ActionPlan, string BusinessImpact);
public sealed record AnalysisResult(NormalizedIncident Incident, IReadOnlyList<IntelligenceFinding> Findings, IReadOnlyList<RootCauseHypothesis> RootCauses, ExecutiveReport Report, IReadOnlyList<AgentContribution> AgentContributions, double Confidence);
