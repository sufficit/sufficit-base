using System.Text.Json;

namespace Sufficit.Finance
{
    /// <summary>
    /// Carries an untrusted provider response from a gateway to the application
    /// runtime. The runtime must sanitize the payload before returning it.
    /// </summary>
    public sealed class BankSlipProviderDiagnosticGatewayResult
    {
        public int HttpStatusCode { get; set; }

        public JsonElement Payload { get; set; }
    }
}
