namespace Sufficit.Finance
{
    /// <summary>
    /// Identifies the strictly read-only provider operation exposed by the
    /// administrative bank slip diagnostics console.
    /// </summary>
    public enum BankSlipProviderDiagnosticOperation : byte
    {
        Authentication = 1,
        Charge = 2
    }
}
