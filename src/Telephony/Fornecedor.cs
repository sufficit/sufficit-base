using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public class Fornecedor
    {
        public static Guid Padrao = Guid.Empty;
        public static Guid GTGI0800 = Guid.Parse("f9fc7cbb-7290-4fba-95cb-ff06bf2aafc6");        
    }

    /// <summary>
    /// External Brazilian Telephony Providers | Suppliers | STFC
    /// </summary>
    public class ExternalProviders
    {
        public static class Contact
        {
            public static Guid Default { get; } = Guid.Empty;

            /// <summary>
            /// Used if provider was not recognized
            /// </summary>
            public static Guid T0800_Default { get; } = Guid.Parse("8c7404d1-7e68-4f77-a535-ee21fc475a61");
            public static Guid T0800_GTGI { get; } = Guid.Parse("f9fc7cbb-7290-4fba-95cb-ff06bf2aafc6");
            public static Guid T0800_ALGAR_A { get; } = Guid.Parse("dff6222b-7388-4f2e-96e6-0c077c30b60f");
            public static Guid T0800_ALGAR_B { get; } = Guid.Parse("107f1060-9d7b-42e5-a84a-4afa4fafd1e0"); 
            public static Guid T0800_ALGAR_C { get; } = Guid.Parse("de6ee3fc-f78d-402d-afd4-277060476606");
        }
    }
}
