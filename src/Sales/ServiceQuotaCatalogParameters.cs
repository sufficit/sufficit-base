using System;
using System.Linq;
using System.Collections.Generic;

namespace Sufficit.Sales;

/// <summary>Cloud Mobile adapter: catalog parameters are the source, profile DTOs remain compatibility views.</summary>
public static class ServiceQuotaCatalogParameters
{
    public const string Enabled = "cloud_mobile.enabled";
    public static ServiceQuotaProfile? Read(ServiceCatalogItem catalog)
    {
        var values = catalog.Parameters.Where(p => p.Key == Enabled || ServiceQuotaContractParameters.IsReserved(p.Key))
            .ToDictionary(p => p.Key, p => p.DefaultValue ?? "");
        if (values.Count == 0) return null;
        var quota = ServiceQuotaContractParameters.Read(values)
            ?? throw new InvalidOperationException("Cloud Mobile catalog quota parameters are incomplete.");
        if (!values.TryGetValue(Enabled, out var enabled) || !bool.TryParse(enabled, out var flag))
            throw new InvalidOperationException("Cloud Mobile catalog availability is required.");
        return new ServiceQuotaProfile { CatalogItemId = catalog.Id, Enabled = flag, Quota = quota };
    }
    public static void Write(ServiceCatalogItem catalog, ServiceQuotaProfile profile)
    {
        var values = new Dictionary<string, string>();
        ServiceQuotaContractParameters.Write(values, profile.Quota);
        ServiceQuotaContractParameters.Read(values); // Validate before changing any definitions.
        values[Enabled] = profile.Enabled ? "true" : "false";
        foreach (var value in values)
        {
            var p = catalog.Parameters.SingleOrDefault(p => p.Key == value.Key);
            if (p == null)
            {
                p = new ServiceCatalogParameterDefinition { Id = Guid.NewGuid(), CatalogItemId = catalog.Id,
                    Key = value.Key, Label = Label(value.Key), Type = value.Key == Enabled || value.Key == ServiceQuotaContractParameters.AllowAdb || value.Key == ServiceQuotaContractParameters.AllowVpn
                        ? ServiceParameterType.Boolean : ServiceParameterType.Integer,
                    Minimum = value.Key == Enabled || value.Key == ServiceQuotaContractParameters.AllowAdb || value.Key == ServiceQuotaContractParameters.AllowVpn ? null : 1,
                    Unit = Unit(value.Key), DisplayOrder = catalog.Parameters.Count };
                catalog.Parameters.Add(p);
            }
            p.DefaultValue = value.Value;
        }
    }
    private static string Label(string key) => key switch {
        Enabled => "Contratação por cotas habilitada", ServiceQuotaContractParameters.MaxInstances => "Instâncias",
        ServiceQuotaContractParameters.MaxCpu => "CPU total", ServiceQuotaContractParameters.MaxMemoryMb => "Memória total",
        ServiceQuotaContractParameters.MaxDiskGb => "Disco total", ServiceQuotaContractParameters.MaxConnections => "Conexões simultâneas",
        ServiceQuotaContractParameters.AllowAdb => "Permitir ADB", ServiceQuotaContractParameters.AllowVpn => "Permitir VPN", _ => key };
    private static string? Unit(string key) => key switch { ServiceQuotaContractParameters.MaxCpu => "vCPU",
        ServiceQuotaContractParameters.MaxMemoryMb => "MB", ServiceQuotaContractParameters.MaxDiskGb => "GB", _ => null };
}
