using Sufficit.Telephony.InterConnection;
using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>Credential-free inputs consumed by the shared route evaluator in memory.</summary>
    public sealed class OutboundRoutingSnapshot
    {
        public IReadOnlyList<OutboundServiceAssignment> Assignments { get; set; } = Array.Empty<OutboundServiceAssignment>();
        public IReadOnlyList<OutboundServiceDidBinding> DidBindings { get; set; } = Array.Empty<OutboundServiceDidBinding>();
        public IReadOnlyList<OutboundRouteRule> Rules { get; set; } = Array.Empty<OutboundRouteRule>();
        public IReadOnlyList<OutboundServicePolicyProfile> Profiles { get; set; } = Array.Empty<OutboundServicePolicyProfile>();
        public IReadOnlyList<OutboundServicePolicyOverride> Overrides { get; set; } = Array.Empty<OutboundServicePolicyOverride>();
        public IReadOnlyList<Interconnection> Interconnections { get; set; } = Array.Empty<Interconnection>();
    }
}
