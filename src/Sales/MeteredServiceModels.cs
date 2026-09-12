using System;

namespace Sufficit.Sales
{
    /// <summary>Identifies the product whose current commercial offer is requested.</summary>
    public sealed class MeteredServiceOfferRequest
    {
        public Guid CatalogItemId { get; set; }
    }

    /// <summary>
    /// Authoritative commercial offer published by Sufficit Endpoints.
    /// Product applications may cache the returned snapshot, but must not create
    /// or override prices, limits or commercial identities.
    /// </summary>
    public sealed class MeteredServiceOffer
    {
        public Guid CatalogItemId { get; set; }
        public Guid TariffId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Currency { get; set; } = "BRL";
        public Guid CpuResourceId { get; set; }
        public Guid MemoryResourceId { get; set; }
        public Guid DiskResourceId { get; set; }
        public long CpuHourMicroBrl { get; set; }
        public long MemoryGiBHourMicroBrl { get; set; }
        public long DiskGb730HoursMicroBrl { get; set; }
        public long MinimumTopupCents { get; set; }
        public long MaximumTopupCents { get; set; }
        public long MinimumInvoiceCents { get; set; }
        public long MaximumInvoiceCents { get; set; }
        public int IncludedCapacityInstances { get; set; }
        public int CapacityCpu { get; set; }
        public int CapacityMemoryMiB { get; set; }
        public int CapacityDiskGb { get; set; }
        public int CapacityConnections { get; set; }
        public bool AllowAdb { get; set; }
        public bool AllowVpn { get; set; }
    }

    /// <summary>Identity and consent sent by a product when accepting a central offer.</summary>
    public sealed class MeteredServiceAgreementRequest
    {
        public Guid ContractId { get; set; }
        public Guid ContextId { get; set; }
        public Guid CatalogItemId { get; set; }
        public Guid TariffId { get; set; }
        public Guid AcceptedBy { get; set; }
        public DateTime AcceptedAtUtc { get; set; }
    }

    /// <summary>Immutable agreement and exact commercial snapshot returned by Endpoints.</summary>
    public sealed class MeteredServiceAgreement
    {
        public Guid ContractId { get; set; }
        public Guid ContextId { get; set; }
        public Guid CatalogItemId { get; set; }
        public Guid AcceptedBy { get; set; }
        public DateTime AcceptedAtUtc { get; set; }
        public MeteredServiceOffer Offer { get; set; } = new MeteredServiceOffer();
    }
}
