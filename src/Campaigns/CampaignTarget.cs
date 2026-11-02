using System;
using System.Collections.Generic;

namespace Sufficit.Campaigns.Models;

/// <summary>Someone the campaign must reach.</summary>
public class CampaignTarget
{
    public Guid Id { get; set; }

    public Guid CampaignId { get; set; }

    /// <summary>Optional link to the contact register.</summary>
    public Guid? ContactId { get; set; }

    public string Name { get; set; } = string.Empty;

    /// <summary>Channel address: phone number, e-mail, handle. Unique per campaign.</summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>Extra values handed to the executor (e.g. company name).</summary>
    public Dictionary<string, string> Variables { get; set; } = new();

    public CampaignTargetStatus Status { get; set; } = CampaignTargetStatus.Pending;

    public int Attempts { get; set; }

    /// <summary>Earliest moment (UTC) the target can be claimed again.</summary>
    public DateTime? NextAttemptAt { get; set; }

    /// <summary>Attempt currently holding the target.</summary>
    public Guid? LeaseAttemptId { get; set; }

    /// <summary>Lease expiry (UTC); an expired lease makes the target claimable again.</summary>
    public DateTime? LeaseExpiresAt { get; set; }

    /// <summary>Data collected so far (e.g. "instagram").</summary>
    public Dictionary<string, string> Result { get; set; } = new();

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
