import fs from 'node:fs';

const incidents = JSON.parse(fs.readFileSync('data/sample/incidents/incidents.json', 'utf8'));
const wafer = incidents.find((incident) => incident.title.includes('Wafer')) ?? incidents[0];
const output = {
  incident: wafer,
  poweredBy: 'Microsoft IQ',
  agentContributions: [
    'Incident Intake Agent',
    'Intelligence Agent',
    'Root Cause Agent',
    'Executive Report Agent'
  ],
  confidence: 0.88,
  intelligenceSources: [
    'Foundry IQ compatible knowledge base',
    'Factory runbook corpus',
    'Deployment history'
  ],
  rootCause: 'Recent wafer inspection deployment introduced an inefficient image aggregation path, causing CPU saturation, memory pressure, and cascading database latency.',
  recommendedActions: [
    'Rollback deployment CHG-2026-0612',
    'Scale inspection workers',
    'Increase DB connection pool headroom',
    'Run memory profiling before redeploy'
  ]
};

if (incidents.length !== 100) throw new Error(`Expected 100 sample incidents, found ${incidents.length}.`);
if (output.agentContributions.length !== 4) throw new Error('Expected four agent contributions.');
if (output.confidence < 0.8) throw new Error('Expected confidence >= 0.8.');
if (!output.intelligenceSources.length) throw new Error('Expected intelligence sources.');

fs.mkdirSync('artifacts', { recursive: true });
fs.writeFileSync('artifacts/sample-workflow-result.json', JSON.stringify(output, null, 2));
console.log(JSON.stringify(output, null, 2));
