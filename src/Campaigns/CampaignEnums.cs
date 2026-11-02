using System;

namespace Sufficit.Campaigns.Models;

public enum CampaignStatus
{
    Draft = 0,
    Active = 1,
    Paused = 2,
    Finished = 3,
}

public enum CampaignTargetStatus
{
    Pending = 0,
    InProgress = 1,
    Succeeded = 2,

    /// <summary>Reached, but the objective was refused / not achieved.</summary>
    Failed = 3,

    /// <summary>Asked not to be contacted again. Final.</summary>
    OptedOut = 4,

    /// <summary>Wrong or unusable address. Final.</summary>
    Invalid = 5,

    /// <summary>Ran out of attempts.</summary>
    Exhausted = 6,

    Cancelled = 7,
}

public enum CampaignOutcome
{
    Succeeded = 0,
    NotAchieved = 1,

    /// <summary>Not reached (no answer, busy, voicemail); retry after the campaign delay.</summary>
    Retry = 2,

    /// <summary>Reached, asked to be contacted later; retry at the requested time.</summary>
    Callback = 3,
    OptOut = 4,
    Invalid = 5,
}

[Flags]
public enum CampaignDays
{
    None = 0,
    Sunday = 1 << 0,
    Monday = 1 << 1,
    Tuesday = 1 << 2,
    Wednesday = 1 << 3,
    Thursday = 1 << 4,
    Friday = 1 << 5,
    Saturday = 1 << 6,
    Weekdays = Monday | Tuesday | Wednesday | Thursday | Friday,
    All = Weekdays | Saturday | Sunday,
}
