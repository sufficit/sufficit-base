using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sufficit.Gateway.ReceitaNet
{
    public enum RNAnnouncer
    {
        /// <summary>
        /// Female google voice
        /// </summary>
        [Description("Google (Voz Feminina)")]
        GOOGLE = 0,

        /// <summary>
        /// Male amazon voice
        /// </summary>
        [Description("Ricardo (Voz Masculina)")]
        RICARDO = 1,

        /// <summary>
        /// Female studio voice
        /// </summary>
        [Description("Raquel (Voz Feminina)")]
        RAQUEL = 2
    }
}
