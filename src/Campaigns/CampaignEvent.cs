using System;
using System.Collections.Generic;

namespace Sufficit.Campaigns.Models;

/// <summary>Event types of the real-time campaign channel (hub method <c>CampaignEvent</c>).</summary>
public static class CampaignEventTypes
{
    public const string AttemptClaimed = "attempt.claimed";
    public const string AttemptDialing = "attempt.dialing";
    public const string AttemptAnswered = "attempt.answered";
    public const string AttemptNotAnswered = "attempt.notanswered";
    public const string DataRecorded = "data.recorded";
    public const string AttemptReported = "attempt.reported";
    public const string TargetStatus = "target.status";
    public const string CampaignStatus = "campaign.status";
    public const string CampaignSummary = "campaign.summary";
}

/// <summary>
/// One change in a campaign, sent live to authorized subscribers of the owner context.
/// Best effort: the API remains the source of truth, clients reconcile through it after reconnecting.
/// </summary>
public sealed class CampaignEvent
{
    /// <summary>One of <see cref="CampaignEventTypes"/>.</summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>Owner context; decides who receives the event.</summary>
    public Guid ContextId { get; set; }

    public Guid CampaignId { get; set; }

    public Guid? TargetId { get; set; }

    public Guid? AttemptId { get; set; }

    public DateTime TimestampUtc { get; set; }

    /// <summary>Attempt outcome (<c>attempt.reported</c>).</summary>
    public CampaignOutcome? Outcome { get; set; }

    /// <summary>Target status (<c>target.status</c>, <c>attempt.reported</c>).</summary>
    public CampaignTargetStatus? TargetStatus { get; set; }

    /// <summary>Campaign status (<c>campaign.status</c>).</summary>
    public CampaignStatus? CampaignStatus { get; set; }

    /// <summary>Free text: attempt summary, dial status.</summary>
    public string? Summary { get; set; }

    /// <summary>Collected data (<c>data.recorded</c>).</summary>
    public Dictionary<string, string>? Data { get; set; }

    /// <summary>Targets per status (<c>campaign.summary</c>).</summary>
    public Dictionary<CampaignTargetStatus, int>? Targets { get; set; }
}
