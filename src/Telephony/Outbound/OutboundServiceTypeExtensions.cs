namespace Sufficit.Telephony.Outbound
{
    public static class OutboundServiceTypeExtensions
    {
        public static uint GetPriorityRank(this OutboundServiceType value)
            => value == OutboundServiceType.UNKNOWN
                ? uint.MaxValue
                : (uint)value;

        public static string GetDisplayLabel(this OutboundServiceType value)
            => value switch
            {
                OutboundServiceType.FIXED_UNLIMITED => "Ilimitado fixo",
                OutboundServiceType.MOBILE_UNLIMITED => "Ilimitado movel",
                OutboundServiceType.SINGLE => "Single",
                OutboundServiceType.FLEX => "Flex / Flex+",
                OutboundServiceType.BILLED => "Tarifado",
                OutboundServiceType.FREE => "Livre",
                OutboundServiceType.SMART_CUSTOMER => "Smart cliente (legado)",
                OutboundServiceType.SMART_GLOBAL => "Smart global (legado)",
                OutboundServiceType.BYOC => "Trunk do cliente",
                _ => value.ToString(),
            };

        public static bool IsCatalogSelectable(this OutboundServiceType value)
            => value is OutboundServiceType.FIXED_UNLIMITED
                or OutboundServiceType.MOBILE_UNLIMITED
                or OutboundServiceType.SINGLE
                or OutboundServiceType.FLEX
                or OutboundServiceType.BILLED
                or OutboundServiceType.FREE;

        public static bool IsSmartLegacyFamily(this OutboundServiceType value)
            => value is OutboundServiceType.SMART_CUSTOMER or OutboundServiceType.SMART_GLOBAL;
    }
}
