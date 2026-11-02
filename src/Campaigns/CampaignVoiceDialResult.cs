namespace Sufficit.Campaigns.Models;

/// <summary>What the voice executor receives after asking the PBX to dial a leased attempt.</summary>
public sealed class CampaignVoiceDialResult
{
    public CampaignVoiceDialResult() { }

    public CampaignVoiceDialResult(bool accepted, string status, string agentEndpointId, bool answered = false, string? reason = null)
    {
        Accepted = accepted;
        Status = status;
        AgentEndpointId = agentEndpointId;
        Answered = answered;
        Reason = reason;
    }

    /// <summary>The PBX accepted the originate request.</summary>
    public bool Accepted { get; set; }

    /// <summary>ANSWER, NOANSWER, TIMEOUT or the PBX response when the request was refused.</summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>Agent extension the call left through (GUID without hyphens).</summary>
    public string AgentEndpointId { get; set; } = string.Empty;

    /// <summary>The customer answered and the agent leg is being dialed.</summary>
    public bool Answered { get; set; }

    /// <summary>Reason reported by the PBX, when it sent one.</summary>
    public string? Reason { get; set; }
}
