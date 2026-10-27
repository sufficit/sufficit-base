using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Cadences
{
    /// <summary>
    ///     Kinds of things a cadence can be applied to. <see cref="CadenceTarget.TargetId"/> holds the identifier in the
    ///     owner's format (Guid "D" string, event id, template title...). Specific targets win over general ones in
    ///     <c>Resolve</c>: the consumer passes its candidates from the most specific to the most general.
    /// </summary>
    public static class CadenceTargetTypes
    {
        public const string SalesCatalogItem = "sales.catalog-item";
        public const string SalesContract = "sales.contract";
        public const string NotificationEvent = "notification.event";
        public const string TelephonyDid = "telephony.did";
        public const string Context = "context";
        public const string Everything = "all";

        public sealed class Descriptor
        {
            public string Key { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public string Module { get; set; } = string.Empty;
        }

        public static IReadOnlyList<Descriptor> All { get; } = new[]
        {
            new Descriptor { Key = SalesCatalogItem, Title = "Tipo de serviço", Module = CadenceModules.Sales },
            new Descriptor { Key = SalesContract, Title = "Contrato", Module = CadenceModules.Sales },
            new Descriptor { Key = NotificationEvent, Title = "Evento de notificação", Module = CadenceModules.Notification },
            new Descriptor { Key = TelephonyDid, Title = "Número (DID)", Module = CadenceModules.Telephony },
            new Descriptor { Key = Context, Title = "Cliente", Module = string.Empty },
            new Descriptor { Key = Everything, Title = "Todos do módulo", Module = string.Empty },
        };

        public static Descriptor? Find(string? key) => All.FirstOrDefault(d => string.Equals(d.Key, key, StringComparison.OrdinalIgnoreCase));

        public static string Title(string? key) => Find(key)?.Title ?? key ?? "";
    }
}
