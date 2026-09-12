using System;

namespace Sufficit.Finance.Credits;

public sealed class CreditUsageRequest
{
    public Guid Id { get; set; }
    public Guid ContextId { get; set; }
    public Guid ProductId { get; set; }
    public Guid ContractId { get; set; }
    public Guid InstanceId { get; set; }
    public DateTime FromUtc { get; set; }
    public DateTime ToUtc { get; set; }
    public long CpuSeconds { get; set; }
    public long MemoryMiBSeconds { get; set; }
    public long DiskGbSeconds { get; set; }
}
