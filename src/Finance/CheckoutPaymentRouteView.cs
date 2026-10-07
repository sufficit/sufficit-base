namespace Sufficit.Finance
{
    /// <summary>Server-only payment requirements resolved from a persisted charge; no environment selector.</summary>
    public sealed class CheckoutPaymentRouteView
    {
        public bool RequiresPayer { get; set; } = true;
        public bool TestPayment { get; set; }
        public string ProviderCustomerId { get; set; } = string.Empty;
    }
}
