using System;
using System.Collections.Generic;
using System.Globalization;

namespace Sufficit.Sales
{
    /// <summary>
    /// Reserved contract parameter keys for the Cloud Mobile quota adapter.
    /// The catalog may define ordinary fields; these keys only become an
    /// entitlement after the central checkout validates and snapshots all seven.
    /// </summary>
    public static class ServiceQuotaContractParameters
    {
        public const string MaxInstances = "cloud_mobile.max_instances";
        public const string MaxCpu = "cloud_mobile.max_cpu";
        public const string MaxMemoryMb = "cloud_mobile.max_memory_mb";
        public const string MaxDiskGb = "cloud_mobile.max_disk_gb";
        public const string MaxConnections = "cloud_mobile.max_connections";
        public const string AllowAdb = "cloud_mobile.allow_adb";
        public const string AllowVpn = "cloud_mobile.allow_vpn";

        public static bool IsReserved(string key)
            => key == MaxInstances || key == MaxCpu || key == MaxMemoryMb ||
               key == MaxDiskGb || key == MaxConnections || key == AllowAdb || key == AllowVpn;

        public static QuotaSpecification? Read(IReadOnlyDictionary<string, string>? values)
        {
            if (values == null) return null;
            var keys = new[] { MaxInstances, MaxCpu, MaxMemoryMb, MaxDiskGb, MaxConnections, AllowAdb, AllowVpn };
            var found = 0;
            foreach (var key in keys)
                if (values.ContainsKey(key)) found++;
            if (found == 0) return null;
            if (found != keys.Length)
                throw new InvalidOperationException("All seven Cloud Mobile contract quota values are required.");

            return new QuotaSpecification
            {
                MaxInstances = Positive(values[MaxInstances]),
                MaxCpu = Positive(values[MaxCpu]),
                MaxMemoryMb = Positive(values[MaxMemoryMb]),
                MaxDiskGb = Positive(values[MaxDiskGb]),
                MaxConnections = Positive(values[MaxConnections]),
                AllowAdb = Boolean(values[AllowAdb]),
                AllowVpn = Boolean(values[AllowVpn])
            };
        }

        public static QuotaSpecification Effective(IReadOnlyDictionary<string, string>? values, QuotaSpecification ceiling)
        {
            if (ceiling == null) throw new ArgumentNullException(nameof(ceiling));
            var quota = Read(values) ?? Copy(ceiling);
            if (quota.MaxInstances > ceiling.MaxInstances || quota.MaxCpu > ceiling.MaxCpu ||
                quota.MaxMemoryMb > ceiling.MaxMemoryMb || quota.MaxDiskGb > ceiling.MaxDiskGb ||
                quota.MaxConnections > ceiling.MaxConnections ||
                (quota.AllowAdb && !ceiling.AllowAdb) || (quota.AllowVpn && !ceiling.AllowVpn))
                throw new InvalidOperationException("Contract quota exceeds the enabled catalog offer.");
            return quota;
        }

        public static void Write(IDictionary<string, string> values, QuotaSpecification quota)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (quota == null) throw new ArgumentNullException(nameof(quota));
            values[MaxInstances] = quota.MaxInstances.ToString(CultureInfo.InvariantCulture);
            values[MaxCpu] = quota.MaxCpu.ToString(CultureInfo.InvariantCulture);
            values[MaxMemoryMb] = quota.MaxMemoryMb.ToString(CultureInfo.InvariantCulture);
            values[MaxDiskGb] = quota.MaxDiskGb.ToString(CultureInfo.InvariantCulture);
            values[MaxConnections] = quota.MaxConnections.ToString(CultureInfo.InvariantCulture);
            values[AllowAdb] = quota.AllowAdb ? "true" : "false";
            values[AllowVpn] = quota.AllowVpn ? "true" : "false";
        }

        public static bool Equals(QuotaSpecification left, QuotaSpecification right)
            => left.MaxInstances == right.MaxInstances && left.MaxCpu == right.MaxCpu &&
               left.MaxMemoryMb == right.MaxMemoryMb && left.MaxDiskGb == right.MaxDiskGb &&
               left.MaxConnections == right.MaxConnections && left.AllowAdb == right.AllowAdb &&
               left.AllowVpn == right.AllowVpn;

        private static QuotaSpecification Copy(QuotaSpecification source) => new QuotaSpecification
        {
            MaxInstances = source.MaxInstances, MaxCpu = source.MaxCpu, MaxMemoryMb = source.MaxMemoryMb,
            MaxDiskGb = source.MaxDiskGb, MaxConnections = source.MaxConnections,
            AllowAdb = source.AllowAdb, AllowVpn = source.AllowVpn
        };

        private static int Positive(string value)
            => int.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out var parsed) && parsed > 0
                ? parsed : throw new InvalidOperationException("Cloud Mobile contract quota requires positive integers.");

        private static bool Boolean(string value)
            => string.Equals(value, "true", StringComparison.OrdinalIgnoreCase) ? true :
                string.Equals(value, "false", StringComparison.OrdinalIgnoreCase) ? false :
                throw new InvalidOperationException("Cloud Mobile contract permissions require true or false.");
    }
}
