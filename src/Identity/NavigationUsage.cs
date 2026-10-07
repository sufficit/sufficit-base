using System;
using System.Collections.Generic;

namespace Sufficit.Identity.Navigation;

/// <summary>Bounded usage metadata for the authenticated user's navigation.</summary>
public sealed class NavigationUsageEntry
{
    public NavigationUsageEntry(string route, long count, double score, long lastVisit)
        => (Route, Count, Score, LastVisit) = (route, count, score, lastVisit);
    public string Route { get; set; }
    public long Count { get; set; }
    public double Score { get; set; }
    public long LastVisit { get; set; }
}

/// <summary>Idempotent navigation usage batch. User identity comes from the session.</summary>
public sealed class NavigationUsageBatch
{
    public NavigationUsageBatch(Guid id, Dictionary<string, int> visits) => (Id, Visits) = (id, visits);
    public Guid Id { get; set; }
    public Dictionary<string, int> Visits { get; set; }
}

/// <summary>Authenticated user's navigation mode.</summary>
public sealed class NavigationMenuPreference
{
    public NavigationMenuPreference(string mode) => Mode = mode;
    public string Mode { get; set; }
}
