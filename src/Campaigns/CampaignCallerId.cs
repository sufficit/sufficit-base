using System;
using System.Collections.Generic;

namespace Sufficit.Campaigns.Models;

/// <summary>Where the outbound number of the campaign agent comes from.</summary>
public enum CampaignCallerIdSource
{
    /// <summary>No caller id row applies.</summary>
    None,

    /// <summary>The agent extension has its own row.</summary>
    Agent,

    /// <summary>Default of the campaign context.</summary>
    Context,

    /// <summary>Default shared by every context.</summary>
    Global,
}

/// <summary>A number of the campaign context that can identify the agent.</summary>
public sealed class CampaignCallerIdOption
{
    public string Number { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}

/// <summary>Outbound identification of the campaign agent and the numbers it can use.</summary>
public sealed class CampaignCallerId
{
    /// <summary>Agent extension from the campaign settings; null when it is not defined or not in the campaign context.</summary>
    public Guid? AgentEndpointId { get; set; }

    public string? AgentTitle { get; set; }

    /// <summary>Number the next call leaves with, as stored for the PBX; null when no row applies.</summary>
    public string? Number { get; set; }

    public string? Name { get; set; }

    public CampaignCallerIdSource Source { get; set; }

    /// <summary>Option the agent's own row points to; null when it follows a default or holds a number outside the options.</summary>
    public string? Selected { get; set; }

    public IReadOnlyList<CampaignCallerIdOption> Options { get; set; } = Array.Empty<CampaignCallerIdOption>();
}

/// <summary>New number for the campaign agent; empty removes its own row, falling back to the default.</summary>
public sealed class CampaignCallerIdUpdate
{
    public string? Number { get; set; }
}
