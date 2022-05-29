using System;

namespace Sufficit.Telephony
{
    [Flags]
    public enum TChamada
    {
        Desconhecido = 0,

        Saida = 1 << 1,
        Entrada = 1 << 2,
        Interna = 1 << 3,

        Movel = 1 << 4,
        MovelNacional = 1 << 5 | Movel,
        MovelInternacional = 1 << 6 | Movel,
        Fixo = 1 << 7,
        FixoNacional = 1 << 8 | Fixo,
        FixoInternacional = 1 << 9 | Fixo,
        Gratuita = 1 << 10
    }
}
