using FactoryIQ.Core.Contracts; using FactoryIQ.Core.Models;
namespace FactoryIQ.Agents;
public sealed class BundledSampleIQProvider : IIQProvider
{
    public Task<IQResult> QueryAsync(string query, CancellationToken ct)
    {
        var sources = new[] { new IQSource("Foundry IQ compatible knowledge base", "FoundryIQ", "High"), new IQSource("Factory runbook corpus", "OperationalKnowledge", "High"), new IQSource("Deployment history", "WorkIQ", "Medium") };
        var citations = new[] { new IQCitation("Wafer inspection runbook", "data/sample/runbooks/wafer-inspection.md", "Runbook"), new IQCitation("Deployment change CHG-2026-0612", "data/sample/incidents/incidents.json", "ChangeRecord") };
        var summary = query.Contains("wafer", StringComparison.OrdinalIgnoreCase) ? "Similar wafer inspection incidents correlated CPU spikes, memory pressure, database latency, and recent image-processing deployment. Recommended rollback and DB connection pool tuning." : "Relevant factory operations intelligence was retrieved from bundled enterprise knowledge sources.";
        return Task.FromResult(new IQResult(query, summary, sources, citations, .91));
    }
}
public sealed class IQProviderFactory { public IIQProvider Create() => new BundledSampleIQProvider(); }
