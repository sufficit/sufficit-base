using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Telephony
{
    public sealed class EndPointSupportRole
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string[] Entitlements { get; set; } = Array.Empty<string>();
    }

    /// <summary>Compatibility catalog for reserved endpoint tags; entitlement interpretation is a consumer of generic tags.</summary>
    public static class EndPointSupportRoles
    {
        public static IReadOnlyList<EndPointSupportRole> Catalog => new[] {
            new EndPointSupportRole { Id = new Guid("8ee6de96-58ab-445c-af48-b0d720df472f"), Title = "Financeiro", Entitlements = new[] { "bankbillet" } },
            new EndPointSupportRole { Id = new Guid("bb46583e-fef6-4bf3-8cac-8be731a01aab"), Title = "Administrador de telefonia", Entitlements = new[] { "telephonyclient", "dialplanupdate", "phonecalls" } },
            new EndPointSupportRole { Id = new Guid("bc7b3e21-ec75-4793-806b-7586c40de8fb"), Title = "Atendimento", Entitlements = new[] { "telephonyclient" } }
        };

        public static Guid[] Normalize(IEnumerable<Guid> roleIds)
        {
            if (roleIds == null) throw new ArgumentException("Informe os cargos; use uma lista vazia para revogar todos.");
            var ids = roleIds.Distinct().OrderBy(x => x).ToArray();
            if (ids.Any(id => !Catalog.Any(role => role.Id == id))) throw new ArgumentException("Cargo de atendimento desconhecido.");
            return ids;
        }

        public static string[] Entitlements(IEnumerable<Guid> roleIds)
        {
            var ids = Normalize(roleIds);
            return Catalog.Where(x => ids.Contains(x.Id)).SelectMany(x => x.Entitlements).Distinct().OrderBy(x => x).ToArray();
        }
    }

    public sealed class EndPointSupportAccess
    {
        public Guid ContextId { get; set; }
        public Guid EndPointId { get; set; }
        public Guid Revision { get; set; }
        public Guid[] RoleIds { get; set; } = Array.Empty<Guid>();
        public string[] Entitlements { get; set; } = Array.Empty<string>();
        public string[] Tags { get; set; } = Array.Empty<string>();
        public bool CanManage { get; set; }
        public bool RestrictionsEnabled { get; set; }
    }

    public sealed class EndPointSupportAccessChange
    {
        public Guid ContextId { get; set; }
        public Guid EndPointId { get; set; }
        public Guid ExpectedRevision { get; set; }
        public string[]? Tags { get; set; }
        public Guid[] RoleIds { get; set; } = Array.Empty<Guid>();
    }

    public sealed class EndPointSupportAccessRecord
    {
        public Guid ContextId { get; set; }
        public Guid EndPointId { get; set; }
        public Guid Revision { get; set; }
        public bool HasConfiguredReservedTags { get; set; } = true;
        public string RolesJson { get; set; } = "[]";
        public string TagsJson { get; set; } = "[]";
    }

    public sealed class EndPointSupportAccessAudit
    {
        public Guid Id { get; set; }
        public Guid ContextId { get; set; }
        public Guid EndPointId { get; set; }
        public Guid Revision { get; set; }
        public string ActorId { get; set; } = string.Empty;
        public DateTime AtUtc { get; set; }
        public string BeforeJson { get; set; } = "[]";
        public string BeforeTagsJson { get; set; } = "[]";
        public string AfterTagsJson { get; set; } = "[]";
        public string AfterJson { get; set; } = "[]";
    }
}
