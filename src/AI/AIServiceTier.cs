namespace Sufficit.AI;

/// <summary>
/// Canonical service tier levels controlling latency/cost trade-offs across providers.
/// </summary>
/// <remarks>
/// <list type="bullet">
///   <item><c>low</c>: Cheaper, higher latency (OpenAI "flex", Anthropic "background").</item>
///   <item><c>default</c>: Standard tier, no special flags sent.</item>
///   <item><c>high</c>: Faster output, may cost more (Anthropic "interactive", OpenAI "auto").</item>
/// </list>
/// </remarks>
public static class AIServiceTier
{
    public const string Low = "low";
    public const string Default = "default";
    public const string High = "high";

    /// <summary>Normalizes known aliases to canonical service tier levels.</summary>
    /// <returns>The canonical tier, or <see langword="null"/> when the value is not recognized or empty.</returns>
    public static string? Normalize(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        return value.Trim().ToLowerInvariant() switch
        {
            "low" or "flex" or "batch" or "background" or "economy" => Low,
            "default" or "standard" or "normal" => Default,
            "high" or "fast" or "priority" or "interactive" or "auto" or "upper" => High,
            _ => null
        };
    }
}
