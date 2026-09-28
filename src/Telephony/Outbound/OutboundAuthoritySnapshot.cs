using System;
using System.Collections.Generic;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>Consistent persisted configuration for one context. Revisions count retained outbox changes.</summary>
    public sealed class OutboundAuthoritySnapshot
    {
        public Guid ContextId { get; set; }
        public long GlobalRevision { get; set; }
        public long ContextRevision { get; set; }
        public string ResourceFingerprint { get; set; } = string.Empty;
        public DateTime LoadedAtUtc { get; set; }
        public IReadOnlyList<OutboundCatalogService> CatalogServices { get; set; }
            = Array.Empty<OutboundCatalogService>();
        public IReadOnlyList<OutboundCustomerService> CustomerServices { get; set; }
            = Array.Empty<OutboundCustomerService>();
        public IReadOnlyList<OutboundCommercialGrantLine> CommercialGrantLines { get; set; }
            = Array.Empty<OutboundCommercialGrantLine>();
        public IReadOnlyList<OutboundRouteSource> RouteSources { get; set; }
            = Array.Empty<OutboundRouteSource>();
        public IReadOnlyList<OutboundRouteGrant> RouteGrants { get; set; }
            = Array.Empty<OutboundRouteGrant>();
        public IReadOnlyList<OutboundSipResource> SipResources { get; set; }
            = Array.Empty<OutboundSipResource>();
    }

    /// <summary>Credential-free physical SIP endpoint bound to one canonical interconnection.</summary>
    public sealed class OutboundSipResource
    {
        public Guid InterconnectionId { get; set; }
        public Guid? OwnerContextId { get; set; }
        public string EndpointId { get; set; } = string.Empty;
        public bool Enabled { get; set; }
        public bool OutboundAllowed { get; set; }
        public int ChannelLimit { get; set; }
    }

    public sealed class OutboundAuthorityRevision
    {
        public Guid ContextId { get; set; }
        public long GlobalRevision { get; set; }
        public long ContextRevision { get; set; }
        public string ResourceFingerprint { get; set; } = string.Empty;
    }
}
