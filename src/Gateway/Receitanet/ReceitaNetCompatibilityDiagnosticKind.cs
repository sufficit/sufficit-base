using System.Text.Json.Serialization;

namespace Sufficit.Gateway.ReceitaNet
{
    /// <summary>
    /// Diagnostic classification for one ReceitaNet compatibility result.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReceitaNetCompatibilityDiagnosticKind
    {
        Compatible = 1,
        TolerableMismatch = 2,
        DeveloperReview = 3,
        TechnicalFailure = 4,
        Skipped = 5,
    }
}
