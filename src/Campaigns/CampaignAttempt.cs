using System;
using System.Collections.Generic;

namespace Sufficit.Campaigns.Models;

/// <summary>One try at reaching a target.</summary>
public class CampaignAttempt
{
    public Guid Id { get; set; }

    public Guid CampaignId { get; set; }

    public Guid TargetId { get; set; }

    /// <summary>1-based attempt number for the target.</summary>
    public int Number { get; set; }

    /// <summary>Who claimed it (executor instance name).</summary>
    public string Executor { get; set; } = string.Empty;

    /// <summary>Channel reference, e.g. ElevenLabs conversation id or call unique id.</summary>
    public string? ExternalId { get; set; }

    public DateTime StartedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public CampaignOutcome? Outcome { get; set; }

    public string? Summary { get; set; }

    /// <summary>Data collected during this attempt.</summary>
    public Dictionary<string, string> Data { get; set; } = new();
}
