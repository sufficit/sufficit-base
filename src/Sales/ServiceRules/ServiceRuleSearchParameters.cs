using System;

namespace Sufficit.Sales
{
    public sealed class ServiceRuleSearchParameters
    {
        public ServiceRuleKind? Kind { get; set; }

        public ServiceRuleStatus? Status { get; set; }

        /// <summary>Only schedules bound to this catalog item.</summary>
        public Guid? CatalogItemId { get; set; }

        public string? Text { get; set; }
    }
}
