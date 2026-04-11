using System;

namespace Sufficit.Telephony.Outbound
{
    /// <summary>
    ///     Stable identifiers for the telephony-owned outbound service catalog.
    /// </summary>
    public static class OutboundCatalogServiceIds
    {
        public static readonly Guid MobileUnlimited = new("6a97e5bd-29fd-4a15-8505-b1739b4f1657");

        public static readonly Guid FixedUnlimited = new("aaa9da9b-5833-49e9-bd8b-1f9f0695d96f");

        public static readonly Guid Flex = new("a42174e8-4e4e-4f6a-8064-ea60e84ebc55");

        public static readonly Guid FlexPlus = new("00fdc823-2d3f-4ad6-bdf0-1a77246f287c");

        public static readonly Guid Single = new("9e1817c8-6553-4853-9189-046abfff26a1");

        public static readonly Guid Billed = new("a385eebd-8207-4919-8fdd-a5f07623e5dc");

        public static readonly Guid Free = new("c1d42b3c-b01f-4a1d-ab88-2377892f6d22");
    }
}
