using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sufficit.Sales
{
    /// <summary>Lifecycle state of one commercial catalog item.</summary>
    public enum ServiceCatalogStatus : byte
    {
        Draft = 0,
        Active = 1,
        Retired = 2
    }

    /// <summary>How the catalog item is charged.</summary>
    public enum ServiceBillingMode : byte
    {
        Recurring = 0,
        OneTime = 1,
        Usage = 2,
        Prepaid = 3
    }

    /// <summary>Commercial measurement unit.</summary>
    public enum ServiceUnit : byte
    {
        Unit = 0,
        Month = 1,
        Hour = 2,
        Minute = 3,
        Gigabyte = 4,
        User = 5,
        Channel = 6,
        Extension = 7,
        Custom = 255
    }

    /// <summary>Supported data types for contract-specific parameters.</summary>
    public enum ServiceParameterType : byte
    {
        Text = 0,
        Integer = 1,
        Decimal = 2,
        Boolean = 3,
        Date = 4,
        Selection = 5,
        Identifier = 6
    }

    /// <summary>Known fiscal obligations. Custom keeps the catalog extensible.</summary>
    public enum ServiceTaxKind : byte
    {
        ISS = 0,
        ICMS = 1,
        PIS = 2,
        COFINS = 3,
        IRPJ = 4,
        CSLL = 5,
        INSS = 6,
        IRRF = 7,
        Custom = 255
    }

    /// <summary>Operational category of a cost component.</summary>
    public enum ServiceCostCategory : byte
    {
        Supplier = 0,
        Infrastructure = 1,
        Licensing = 2,
        Labor = 3,
        Telecom = 4,
        Commission = 5,
        Operational = 6,
        Other = 255
    }

    /// <summary>How a cost component contributes to the estimated unit cost.</summary>
    public enum ServiceCostCalculationMode : byte
    {
        Fixed = 0,
        PerUnit = 1,
        PercentageOfPrice = 2
    }

    /// <summary>
    ///     ERP catalog definition used as the commercial and operational template
    ///     for customer contracts.
    /// </summary>
    public class ServiceCatalogItem
    {
        public Guid Id { get; set; }

        [Required, StringLength(64)]
        public string Code { get; set; } = string.Empty;

        [Required, StringLength(250)]
        public string Name { get; set; } = string.Empty;

        [StringLength(120)]
        public string? Category { get; set; }

        public string? Description { get; set; }

        public ServiceCatalogStatus Status { get; set; } = ServiceCatalogStatus.Active;

        public ServiceBillingMode BillingMode { get; set; } = ServiceBillingMode.Recurring;

        public ServiceUnit Unit { get; set; } = ServiceUnit.Month;

        [Required, StringLength(3)]
        public string Currency { get; set; } = "BRL";

        public decimal DefaultPrice { get; set; }

        public uint BillingCycleMonths { get; set; } = 1;

        public ContractProrationMode ProrationMode { get; set; } = ContractProrationMode.Daily;

        [StringLength(64)]
        public string? FiscalProfileCode { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;

        public List<ServiceCatalogParameterDefinition> Parameters { get; set; } = new();

        public List<ServiceCatalogTaxRule> Taxes { get; set; } = new();

        public List<ServiceCatalogCostComponent> Costs { get; set; } = new();

        /// <summary>Number of contracts currently linked to this type.</summary>
        [NotMapped]
        public int UsageCount { get; set; }
    }

    /// <summary>Schema entry for one value that must be collected per contract.</summary>
    public class ServiceCatalogParameterDefinition
    {
        public Guid Id { get; set; }
        public Guid CatalogItemId { get; set; }

        [Required, StringLength(64)]
        public string Key { get; set; } = string.Empty;

        [Required, StringLength(120)]
        public string Label { get; set; } = string.Empty;

        public ServiceParameterType Type { get; set; } = ServiceParameterType.Text;
        public bool Required { get; set; }

        [StringLength(250)]
        public string? DefaultValue { get; set; }

        [StringLength(32)]
        public string? Unit { get; set; }

        /// <summary>One selection value per line when <see cref="Type"/> is Selection.</summary>
        public string? Options { get; set; }

        [StringLength(250)]
        public string? HelpText { get; set; }

        [StringLength(250)]
        public string? ValidationPattern { get; set; }

        public decimal? Minimum { get; set; }
        public decimal? Maximum { get; set; }
        public int DisplayOrder { get; set; }
    }

    /// <summary>Fiscal rule used for price and margin simulation.</summary>
    public class ServiceCatalogTaxRule
    {
        public Guid Id { get; set; }
        public Guid CatalogItemId { get; set; }
        public ServiceTaxKind Kind { get; set; } = ServiceTaxKind.ISS;

        [StringLength(64)]
        public string? Code { get; set; }

        [StringLength(120)]
        public string? Name { get; set; }

        public decimal Rate { get; set; }
        public decimal BasisPercentage { get; set; } = 100m;
        public decimal FixedAmount { get; set; }
        public bool IncludedInPrice { get; set; } = true;
        public bool Withheld { get; set; }
        public bool Recoverable { get; set; }

        [StringLength(64)]
        public string? Jurisdiction { get; set; }

        [StringLength(64)]
        public string? FiscalOperationCode { get; set; }

        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveUntil { get; set; }
        public int DisplayOrder { get; set; }
    }

    /// <summary>One direct-cost line in the standard cost composition.</summary>
    public class ServiceCatalogCostComponent
    {
        public Guid Id { get; set; }
        public Guid CatalogItemId { get; set; }

        [Required, StringLength(120)]
        public string Name { get; set; } = string.Empty;

        public ServiceCostCategory Category { get; set; } = ServiceCostCategory.Operational;
        public ServiceCostCalculationMode CalculationMode { get; set; } = ServiceCostCalculationMode.Fixed;
        public decimal Amount { get; set; }
        public decimal Quantity { get; set; } = 1m;
        public decimal Rate { get; set; }

        [StringLength(32)]
        public string? Unit { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public bool Active { get; set; } = true;
        public int DisplayOrder { get; set; }
    }

    /// <summary>Complex search body for the service catalog POST /search route.</summary>
    public class ServiceCatalogSearchParameters : ILimit
    {
        public TextFilter? Filter { get; set; }
        public ServiceCatalogStatus? Status { get; set; }
        public ServiceBillingMode? BillingMode { get; set; }
        public string? Category { get; set; }
        public uint? Limit { get; set; }
    }

    /// <summary>Calculated pricing indicators for management and approval.</summary>
    public class ServiceCatalogPricingSummary
    {
        public decimal BasePrice { get; set; }
        public decimal DirectCost { get; set; }
        public decimal EstimatedTaxes { get; set; }
        public decimal RecoverableTaxes { get; set; }
        public decimal TaxBurden { get; set; }
        public decimal CustomerPrice { get; set; }
        public decimal ContributionMargin { get; set; }
        public decimal ContributionMarginPercentage { get; set; }
    }

    /// <summary>Deterministic pricing simulation shared by UI, API and tests.</summary>
    public static class ServiceCatalogPricingCalculator
    {
        public static ServiceCatalogPricingSummary Calculate(ServiceCatalogItem item, DateTime? effectiveAt = null)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var price = item.DefaultPrice;
            var moment = (effectiveAt ?? DateTime.UtcNow).Date;
            var directCost = item.Costs
                .Where(component => component.Active)
                .Sum(component => CalculateCost(component, price));

            var effectiveTaxes = item.Taxes.Where(rule =>
                (!rule.EffectiveFrom.HasValue || rule.EffectiveFrom.Value.Date <= moment)
                && (!rule.EffectiveUntil.HasValue || rule.EffectiveUntil.Value.Date >= moment))
                .ToArray();
            var estimatedTaxes = effectiveTaxes.Sum(rule => CalculateTax(rule, price));
            var recoverableTaxes = effectiveTaxes
                .Where(rule => rule.Recoverable)
                .Sum(rule => CalculateTax(rule, price));
            var taxesOutsidePrice = effectiveTaxes
                .Where(rule => !rule.IncludedInPrice)
                .Sum(rule => CalculateTax(rule, price));
            var taxBurden = estimatedTaxes - recoverableTaxes;
            var margin = price - directCost - taxBurden;

            return new ServiceCatalogPricingSummary()
            {
                BasePrice = Round(price),
                DirectCost = Round(directCost),
                EstimatedTaxes = Round(estimatedTaxes),
                RecoverableTaxes = Round(recoverableTaxes),
                TaxBurden = Round(taxBurden),
                CustomerPrice = Round(price + taxesOutsidePrice),
                ContributionMargin = Round(margin),
                ContributionMarginPercentage = price == 0m ? 0m : Round(margin / price * 100m)
            };
        }

        private static decimal CalculateCost(ServiceCatalogCostComponent component, decimal price)
            => component.CalculationMode switch
            {
                ServiceCostCalculationMode.PerUnit => component.Amount * component.Quantity,
                ServiceCostCalculationMode.PercentageOfPrice => price * component.Rate / 100m,
                _ => component.Amount
            };

        private static decimal CalculateTax(ServiceCatalogTaxRule rule, decimal price)
            => rule.FixedAmount + (price * rule.BasisPercentage / 100m * rule.Rate / 100m);

        private static decimal Round(decimal value)
            => Math.Round(value, 4, MidpointRounding.AwayFromZero);
    }
}
