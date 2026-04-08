using System.Text.Json.Serialization;

namespace Sufficit.Gateway.ReceitaNet
{
    /// <summary>
    /// Supported ReceitaNet API operations for compatibility checks.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReceitaNetCompatibilityOperation
    {
        ContractByDocument = 1,
        ContractByPhone = 2,
        ConnectionStatus = 3,
        ChargeNotification = 4,
        PaymentNotification = 5,
        Ticket = 6,
        Recording = 7,
    }
}