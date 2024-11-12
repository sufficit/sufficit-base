using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Sufficit.Telefonia.Tempo
{
    //[Obsolete("2024/08/07 use Telephony TimeInterval instead")]
    public abstract class IntervaloBase
    {
        #region PROPRIEDADES

        public int HoraInicio { get; set; }
        public int HoraFim { get; set; }

        public int DiaInicio { get; set; }
        public int DiaFim { get; set; }

        public int MesDiaInicio { get; set; }
        public int MesDiaFim { get; set; }

        public int MesInicio { get; set; }
        public int MesFim { get; set; }

        #endregion        
        #region  OVERRIDES & IMPLICIT

        public override bool Equals(object? obj)
            => obj is IntervaloBase other &&
                other.HoraInicio == HoraInicio &&
                other.HoraFim == HoraFim &&
                other.DiaInicio == DiaInicio &&
                other.DiaFim == DiaFim &&
                other.MesDiaInicio == MesDiaInicio &&
                other.MesDiaFim == MesDiaFim &&
                other.MesInicio == MesInicio &&
                other.MesFim == MesFim;

        public override int GetHashCode()
            => (HoraInicio, HoraFim, DiaInicio, DiaFim, MesDiaInicio, MesDiaFim, MesInicio, MesFim).GetHashCode();

        #endregion
    }
}
