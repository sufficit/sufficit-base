# Automatic customer suggestions for service date review

## Outcome
The manager opens /pages/sales/services/history-review without selecting a customer. The selected Brazilian month drives a server-side list of customers with different service start days. Each suggestion shows the customer title, observed days, record count and an explicit comparison action. Differences remain candidates for review, never automatic corrections.

## Implementation and limits
Base owns typed results and deterministic grouping. The manager-only API validates current commercial authority and uses the existing BalanceView access guard, including its existing manager exemption. Contact titles come from one bounded visible-contact stream rather than individual browser requests. Source coverage and display are separate: up to 10,000 records in the selected month, at most 250 customer suggestions; either cap marks the result partial. Exact month boundaries are inclusive. A single service or identical wrong dates across services cannot be detected by this rule. Spreadsheet remains read-only.

The initial 500-row bound omitted the task example. Live evidence drove widening the source bound while retaining the candidate cap. Typed Client transport, URL-preserved month/customer drill-down, safe existing revision/retry correction workflow and the read-only AI sidecar are retained. Entry never adopts the globally selected customer.

## Integration and publication
User explicitly approved integration/publication with “autorizo”. Initial main commits: Base c2d5a59, Client bc7839a, Endpoints 17b683d, Blazor 171c7e1. Coverage/boundary follow-ups: Base 0580a87, Endpoints e52e540, Blazor d7c0d6f/56f5818. Confirmed packages: Base 1.26.1007.1741 and 1.26.1007.1748, Client 1.26.1007.1749. Client minimum Base is 1741; API/Blazor minimum Base is 1748; Blazor minimum Client is 1749. Package minimum updates preserve independent Identity requirements.

Deployment used official deploy.py entry points from original repository roots. The first Blazor upload lost its shared staging directory during another active official publication; that installed commit already contained the initial feature. The final API and Blazor official deployments both succeeded. Task feature worktrees held isolated commits only, not deployment copies. Original branches and unrelated documentation were preserved.

Installed public health verified Healthy API 1.26.1007.1748+e52e540692169ae78affdf389d2dc6720eef2e0c and Blazor 1.26.1007.1748+56f5818d4e13b072028b0e724b97708db5f0bf41 on eveo-apps. Later commits update package floors and documentation; no application version field was changed.

## Acceptance evidence
Eleven focused tests passed, including Brazilian date grouping, unchanged source, aligned customers omitted, source cap and independent display cap. Real API/Blazor publication builds succeeded; existing warnings remain. Responsive synthetic browser checks passed automatic suggestions, customer drill-down, reviewed correction receipt, URL preservation and no horizontal overflow at 1280/800/390 pixels.

Authenticated tablet final acceptance for June 2026: 1,381 records inspected, 194 suggestions, no selected context parameter on entry, no error/overflow and the task example present with days 6/8. Clicking its suggestion opened the correct customer and two service records. Returned to the suggestion overview; no production correction was submitted. Private evidence: tmp/history-suggestions-summary.json, history-suggestions-drilldown.json and final health/deployment logs.

## Remaining independent observations
The previously observed June receipt/source-date discrepancy is documented in the earlier history-review delivery record; this publication does not repair customer data. Base/Client package workflows succeeded after NuGet availability resolved. Application CI was retriggered/superseded by newer main commits and is not claimed completed here; the installed manual versions and authenticated behavior were verified independently.
