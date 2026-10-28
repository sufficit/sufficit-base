using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Sales
{
    /// <summary>Explicit presentation grouping; leaves each commercial offer identity intact.</summary>
    public sealed class ServiceCatalogOrganization
    {
        public Guid? ProductId { get; set; }
        public string? Modality { get; set; }
    }

    /// <summary>Internal declarative evidence. Never used to calculate prices, costs or taxes.</summary>
    public sealed class ServiceFiscalComposition
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal? Participation { get; set; }
        public string? Responsible { get; set; }
        public string? Notes { get; set; }
        public string? Reference { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveUntil { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Description) || Description.Length > 250)
                throw new InvalidOperationException("Informe a descrição do componente (até 250 caracteres).");
            if (Participation.HasValue && (Participation.Value < 0 || Participation.Value > 100))
                throw new InvalidOperationException("A participação deve estar entre 0 e 100%, ou ficar em branco.");
            if (EffectiveFrom.HasValue && EffectiveUntil.HasValue && EffectiveFrom.Value.Date > EffectiveUntil.Value.Date)
                throw new InvalidOperationException("O fim da vigência não pode ser anterior ao início.");
            if ((Responsible?.Length ?? 0) > 250 || (Reference?.Length ?? 0) > 2000 || (Notes?.Length ?? 0) > 10000)
                throw new InvalidOperationException("Responsável, referência ou observações excedem o limite de tamanho.");
        }
    }

    public static class ServiceCatalogSelection
    {
        public static Guid ProductId(ServiceCatalogItem item) => item.Organization?.ProductId ?? item.Id;

        /// <summary>Existing binding can remain visible, even if retired. Other offers must be active.</summary>
        public static bool Selectable(ServiceCatalogItem item, Guid? currentId)
            => item.Status == ServiceCatalogStatus.Active || item.Id == currentId;

        public static IEnumerable<ServiceCatalogItem> Products(IEnumerable<ServiceCatalogItem> items, Guid? currentId)
        {
            var all = items.ToArray();
            var ids = new HashSet<Guid>(all.Where(x => Selectable(x, currentId)).Select(ProductId));
            return all.Where(x => x.Organization?.ProductId == null && ids.Contains(x.Id)
                && (x.Status != ServiceCatalogStatus.Retired || all.Any(c => c.Id == currentId && ProductId(c) == x.Id)))
                .OrderBy(x => x.Name, StringComparer.CurrentCultureIgnoreCase);
        }

        public static IEnumerable<ServiceCatalogItem> Modalities(IEnumerable<ServiceCatalogItem> items, Guid productId, Guid? currentId)
            => items.Where(x => x.Organization?.ProductId == productId && Selectable(x, currentId))
                .OrderBy(x => x.Organization!.Modality, StringComparer.CurrentCultureIgnoreCase);
    }
}
