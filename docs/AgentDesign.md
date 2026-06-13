# Agent Design

All agents exchange typed JSON DTOs only.

1. Incident Intake Agent: parses incidents and normalizes symptoms.
2. Intelligence Agent: queries the `IIQProvider` abstraction and emits findings.
3. Root Cause Agent: generates hypotheses, confidence scores, and actions.
4. Executive Report Agent: produces executive summary, technical summary, action plan, and business impact.
