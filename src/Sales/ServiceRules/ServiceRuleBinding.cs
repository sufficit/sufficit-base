using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Applies a schedule to every contract of a catalog item, or to a single contract when
    ///     <see cref="ContractId"/> is set (contract binding wins over the catalog one).
    /// </summary>
    public sealed class ServiceRuleBinding
    {
        public Guid Id { get; set; }

        public Guid RuleId { get; set; }

        public Guid CatalogItemId { get; set; }

        public Guid? ContractId { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        [NotMapped]
        public string? CatalogItemName { get; set; }
    }
}
