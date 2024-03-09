using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Sales
{
    /// <summary>
    ///     Partial (Sales) constants deep class
    /// </summary>
    public struct Constants
    {
        #region TELEPHONY

        public const string SERVICE_TRUNK_BILLED = "TRONCO TARIFADO";
        public const string SERVICE_TRUNK_SINGLE = "TRONCO INDIVIDUAL";
        public const string SERVICE_TRUNK_INBOUND = "TRONCO DE ENTRADA";

        public const string SERVICE_TRUNK_FLEX = "TRONCO FLEXIVEL";
        public const string SERVICE_TRUNK_SHARED = "TRONCO COMPARTILHADO";
        
        public const string SERVICE_TRUNK_FIXED_UNLIMITED = "TRONCO FIXO ILIMITADO";
        public const string SERVICE_TRUNK_MOBILE_UNLIMITED = "TRONCO MOVEL ILIMITADO";


        public const string SERVICE_FLASH_OPERATOR_PANEL = "FLASH OPERATOR PANEL";
        public const string SERVICE_EXTERNAL_INTEGRATION = "MENU INTEGRADO"; 
        public const string SERVICE_ADITIONAL_EXTENSIONS = "RAMAIS ADICIONAIS";

        #endregion

        public const string SERVICE_BUSINESS_SUPPORT_LOCAL = "SUPORTE IN LOCO TERCEIRIZADO";
        public const string SERVICE_BUSINESS_SUPPORT = "SUPORTE EMPRESARIAL";
        public const string SERVICE_CHATWOOT_HOSTING = "HOSPEDAGEM CHATWOOT";
        public const string SERVICE_CUSTOM = "PERSONALIZADO";
    }
}
