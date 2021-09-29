using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sufficit
{
    /// <summary>
    /// Facilitador para Offset em relatórios e ajuste de horarios dentro do sistema
    /// </summary>
    [Serializable]
    [DefaultValue(BRASILIA)]
    public enum RegionEnum
    {
        RIO_BRANCO = -5,

        MANAUS = -4,

        BRASILIA = -3,
        SAO_PAULO = BRASILIA,
        AMERICA_SAO_PAULO = BRASILIA,

        NORONHA = -2
    }
}
