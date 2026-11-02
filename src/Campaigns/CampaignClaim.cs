using System;
using System.Collections.Generic;

namespace Sufficit.Campaigns.Models;

/// <summary>What an executor receives when it claims work.</summary>
public sealed class CampaignClaim
{
    public CampaignClaim() { }

    public CampaignClaim(Campaign campaign, CampaignTarget target, CampaignAttempt attempt)
    {
        Campaign = campaign;
        Target = target;
        Attempt = attempt;
    }

    public Campaign Campaign { get; set; } = default!;

    public CampaignTarget Target { get; set; } = default!;

    public CampaignAttempt Attempt { get; set; } = default!;
}

/// <summary>Executor report closing an attempt.</summary>
public sealed class CampaignAttemptReport
{
    public CampaignOutcome Outcome { get; set; }

    public string? Summary { get; set; }

    public string? ExternalId { get; set; }

    /// <summary>Only for <see cref="CampaignOutcome.Callback"/>: requested moment (UTC).</summary>
    public DateTime? CallbackAt { get; set; }

    public Dictionary<string, string>? Data { get; set; }
}

public sealed class CampaignTargetInput
{
    public Guid? ContactId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public Dictionary<string, string>? Variables { get; set; }
}

public sealed class CampaignSummary
{
    public CampaignSummary() { }

    public CampaignSummary(Guid campaignId, Dictionary<CampaignTargetStatus, int> targets)
    {
        CampaignId = campaignId;
        Targets = targets;
    }

    public Guid CampaignId { get; set; }

    public Dictionary<CampaignTargetStatus, int> Targets { get; set; } = new();
}
