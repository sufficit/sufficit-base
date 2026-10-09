using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Sales;

/// <summary>Read-only communication destination. Never creates a profile or changes fiscal ownership.</summary>
public static class ServiceCollectionRecipient
{
    public static ServiceCollectionProfile? Resolve(Guid contract, Guid customer, ServiceCollectionProfile? explicitProfile,
        IEnumerable<RepresentativeAssignment> assignments, DateTime nowUtc)
    {
        if (explicitProfile != null) return explicitProfile;
        var financial = assignments.Where(x => x.CustomerId == customer && x.IsActiveAt(nowUtc) &&
            (x.Roles & RepresentativeRoles.FinancialResponsible) != 0).ToList();
        if (financial.Count > 1) return null;
        var recipient = financial.Count == 1 ? financial[0].RepresentativeId : customer;
        if (recipient == Guid.Empty) return null;
        // Revision zero means there is no saved override, not that a manager confirmed the recipient.
        return new() { ContractId = contract, ResponsibleContextId = recipient };
    }

    public static bool Matches(ServiceCollectionProfile? current, Guid recipient, long revision)
        => current != null && recipient != Guid.Empty && revision >= 0 &&
            current.ResponsibleContextId == recipient && current.Revision == revision;
}
