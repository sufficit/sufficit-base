using System;
using System.Collections.Generic;

namespace Sufficit.Campaigns.Models;

/// <summary>
/// An outreach goal executed against a list of targets by some channel executor
/// (voice agent, WhatsApp, e-mail...). The library does not know the channels; it only
/// schedules targets, leases them to executors and records outcomes.
/// </summary>
public class Campaign
{
    public Guid Id { get; set; }

    /// <summary>Owner context (customer); <see cref="Guid.Empty"/> means internal/global.</summary>
    public Guid ContextId { get; set; }

    public string Title { get; set; } = string.Empty;

    /// <summary>What counts as success, in plain language (read by humans and agents).</summary>
    public string Objective { get; set; } = string.Empty;

    /// <summary>Script / prompt for the executor.</summary>
    public string? Instructions { get; set; }

    /// <summary>Executor kind that may claim targets (e.g. "voice"). Free text, lower case.</summary>
    public string Channel { get; set; } = string.Empty;

    public CampaignStatus Status { get; set; } = CampaignStatus.Draft;

    /// <summary>Attempts allowed per target before it is exhausted.</summary>
    public int MaxAttempts { get; set; } = 3;

    /// <summary>Delay before retrying a target after a retryable outcome.</summary>
    public int RetryDelayMinutes { get; set; } = 120;

    /// <summary>IANA time zone used by the contact window.</summary>
    public string TimeZone { get; set; } = "America/Sao_Paulo";

    /// <summary>Minute of the local day the window opens (inclusive).</summary>
    public int WindowStartMinute { get; set; } = 9 * 60;

    /// <summary>Minute of the local day the window closes (exclusive).</summary>
    public int WindowEndMinute { get; set; } = 18 * 60;

    /// <summary>Allowed local week days.</summary>
    public CampaignDays WindowDays { get; set; } = CampaignDays.Weekdays;

    /// <summary>Executor-specific settings (JSON), e.g. agent id and caller id for voice.</summary>
    public string? Settings { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
