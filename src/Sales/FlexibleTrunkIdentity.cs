using System;

namespace Sufficit.Sales
{
    /// <summary>Stable commercial identity; historical labels are input aliases, never new product identities.</summary>
    public static class FlexibleTrunkIdentity
    {
        public static readonly Guid CatalogId = new Guid("942a6723-25a2-f111-824e-f26e44c3a574");
        public static readonly Guid DuplicateCatalogId = new Guid("cf296723-25a2-f111-824e-f26e44c3a574");
        public static bool IsName(string? name) => string.Equals(name, Constants.SERVICE_TRUNK_FLEX, StringComparison.OrdinalIgnoreCase)
            || string.Equals(name, Constants.SERVICE_TRUNK_FLEX_PLUS, StringComparison.OrdinalIgnoreCase)
            || string.Equals(name, Constants.SERVICE_TRUNK_SHARED, StringComparison.OrdinalIgnoreCase);
        public static bool IsContract(Contract contract) => contract.CatalogItemId.HasValue
            ? contract.CatalogItemId == CatalogId || contract.CatalogItemId == DuplicateCatalogId
            : IsName(contract.Title);
        public static bool IsCanonicalRename(Contract before, Contract after) => before.CatalogItemId == CatalogId
            && after.CatalogItemId == CatalogId && before.SourceKey == after.SourceKey
            && ((before.Title == Constants.SERVICE_TRUNK_SHARED && after.Title == Constants.SERVICE_TRUNK_FLEX)
                || ((before.Title == Constants.SERVICE_TRUNK_SHARED || before.Title == Constants.SERVICE_TRUNK_FLEX)
                    && after.Title == Constants.SERVICE_TRUNK_FLEX_PLUS));
        public static string CanonicalName(string name) => string.Equals(name, Constants.SERVICE_TRUNK_SHARED, StringComparison.OrdinalIgnoreCase) ? Constants.SERVICE_TRUNK_FLEX_PLUS : name;
        public static string CanonicalName(Guid? catalogId, string name) => catalogId == CatalogId && IsName(name)
            ? Constants.SERVICE_TRUNK_FLEX_PLUS : CanonicalName(name);
    }
}
