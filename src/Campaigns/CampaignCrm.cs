using System;
using System.Collections.Generic;

namespace Sufficit.Campaigns.Models;

/// <summary>What happens to a collected value when the reviewed target is applied.</summary>
public enum CampaignCrmItemStatus
{
    /// <summary>The contact has no value for this attribute: applying writes it.</summary>
    New,

    /// <summary>The contact already has this same value.</summary>
    Same,

    /// <summary>The contact has a different value: it is never overwritten, a person resolves it with the customer.</summary>
    Conflict,

    /// <summary>No contact linked, or the permission this value depends on was not collected.</summary>
    NotAllowed,
}

/// <summary>One collected value compared with the contact records.</summary>
public sealed class CampaignCrmItem
{
    public CampaignCrmItem() { }

    public CampaignCrmItem(string data, string key, string description, string value, string? current, CampaignCrmItemStatus status, bool written = false)
    {
        Data = data;
        Key = key;
        Description = description;
        Value = value;
        Current = current;
        Status = status;
        Written = written;
    }

    /// <summary>Name of the collected value in the target result.</summary>
    public string Data { get; set; } = string.Empty;

    public string Key { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;

    /// <summary>Value the contact holds today, when it has one.</summary>
    public string? Current { get; set; }

    public CampaignCrmItemStatus Status { get; set; }

    /// <summary>Written by this apply and confirmed by reading it back.</summary>
    public bool Written { get; set; }
}

/// <summary>What a target collected, compared with its contact.</summary>
public sealed class CampaignCrmTarget
{
    public CampaignCrmTarget() { }

    public CampaignCrmTarget(Guid targetId, string name, Guid? contactId, IReadOnlyList<CampaignCrmItem> items)
    {
        TargetId = targetId;
        Name = name;
        ContactId = contactId;
        Items = items;
    }

    public Guid TargetId { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid? ContactId { get; set; }

    public IReadOnlyList<CampaignCrmItem> Items { get; set; } = Array.Empty<CampaignCrmItem>();
}

/// <summary>Reviewed targets whose new values may be written to the contact records.</summary>
public sealed class CampaignCrmApplyRequest
{
    public CampaignCrmApplyRequest() { }

    public CampaignCrmApplyRequest(IReadOnlyList<Guid> targetIds)
    {
        TargetIds = targetIds;
    }

    public IReadOnlyList<Guid> TargetIds { get; set; } = Array.Empty<Guid>();
}
