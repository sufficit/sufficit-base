using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Finance
{
    /// <summary>
    /// Resolves the active finance tenant independently from the customer context.
    /// </summary>
    public interface IBankSlipTenantResolver
    {
        Task<Guid> GetRequiredTenantIdAsync(
            ClaimsPrincipal principal,
            CancellationToken cancellationToken);
    }
}
