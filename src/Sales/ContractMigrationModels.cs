using System;
using System.Collections.Generic;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Controls a repeatable import from the legacy sales services table.
    /// </summary>
    public sealed class ContractMigrationRequest
    {
        /// <summary>
        ///     Optional customer context. Null imports every available context.
        /// </summary>
        public Guid? ContextId { get; set; }

        /// <summary>
        ///     Preview changes without writing to the destination database.
        /// </summary>
        public bool DryRun { get; set; } = true;

        /// <summary>
        ///     Includes expired and renewed legacy records when building chains.
        /// </summary>
        public bool IncludeInactive { get; set; } = true;

        /// <summary>
        ///     Rebuilds projected periods and adjustments. It never creates
        ///     financial ledger entries or enables contract automation.
        /// </summary>
        public bool RebuildArtifacts { get; set; }

        /// <summary>
        ///     Maximum number of item details returned in the report.
        /// </summary>
        public uint DetailLimit { get; set; } = 250;
    }

    public enum ContractMigrationAction : byte
    {
        Unchanged = 0,
        Create = 1,
        Update = 2,
        Conflict = 3,
        Skipped = 4
    }

    public sealed class ContractMigrationItem
    {
        public Guid ContractId { get; set; }
        public Guid ContextId { get; set; }
        public string SourceKey { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public ContractMigrationAction Action { get; set; }
        public string? Message { get; set; }
    }

    /// <summary>
    ///     Reconciliation report returned by preview and apply operations.
    /// </summary>
    public sealed class ContractMigrationResult
    {
        public bool DryRun { get; set; }
        public Guid? ContextId { get; set; }
        public int SourceRecords { get; set; }
        public int SourceGroups { get; set; }
        public int Created { get; set; }
        public int Updated { get; set; }
        public int Unchanged { get; set; }
        public int Conflicts { get; set; }
        public int Skipped { get; set; }
        public DateTime CompletedAtUtc { get; set; }
        public IList<ContractMigrationItem> Items { get; set; } = new List<ContractMigrationItem>();
    }
}
