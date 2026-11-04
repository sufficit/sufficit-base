using System;
using System.Threading;
using System.Threading.Tasks;
namespace Sufficit.Finance;
public interface IDirectBillingGuard
{
    Task<IDisposable> AcquireDirectBilling(Guid payer, CancellationToken cancellationToken);
}

public sealed class DirectBillingDisabledException : InvalidOperationException
{
    public DirectBillingDisabledException() : base("Cobrança direta desabilitada para este cliente. Utilize o responsável financeiro cadastrado.") { }
}
