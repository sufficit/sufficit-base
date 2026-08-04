namespace Sufficit.Finance
{
    /// <summary>
    /// Resolves a gateway by its stable persisted provider code.
    /// </summary>
    public interface IBankSlipGatewayResolver
    {
        IBankSlipGateway GetRequired(string providerCode);
    }
}
