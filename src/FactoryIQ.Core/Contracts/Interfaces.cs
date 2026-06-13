using FactoryIQ.Core.Models;
namespace FactoryIQ.Core.Contracts;
public interface IIncidentIntakeAgent { Task<NormalizedIncident> NormalizeAsync(IncidentInput input, CancellationToken ct); }
public interface IIntelligenceAgent { Task<IReadOnlyList<IntelligenceFinding>> AnalyzeAsync(NormalizedIncident incident, CancellationToken ct); }
public interface IRootCauseAgent { Task<IReadOnlyList<RootCauseHypothesis>> AnalyzeAsync(NormalizedIncident incident, IReadOnlyList<IntelligenceFinding> findings, CancellationToken ct); }
public interface IExecutiveReportAgent { Task<ExecutiveReport> CreateAsync(NormalizedIncident incident, IReadOnlyList<IntelligenceFinding> findings, IReadOnlyList<RootCauseHypothesis> causes, CancellationToken ct); }
public interface IIQProvider { Task<IQResult> QueryAsync(string query, CancellationToken ct); }
public interface IIncidentAnalysisOrchestrator { Task<AnalysisResult> AnalyzeAsync(IncidentInput input, CancellationToken ct); }
