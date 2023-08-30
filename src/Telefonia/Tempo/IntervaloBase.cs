using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Sufficit.Telefonia.Tempo
{
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

        public override string ToString()
        {
            //09:00-18:00|mon-fri|2-12|feb-jul
            string resultado = string.Empty;
            string item = string.Empty;
            if (HoraInicio == 0 && HoraFim == 0) { resultado += "*"; }
            else
            {
                item = HoraInicio.ToString().PadLeft(4, '0');
                resultado += item.Substring(0, 2) + ":" + item.Substring(2, 2);
                resultado += "-";
                item = HoraFim.ToString().PadLeft(4, '0');
                resultado += item.Substring(0, 2) + ":" + item.Substring(2, 2);
            }
            resultado += "|";
            if (DiaInicio == 0) { resultado += "*"; }
            else
            {
                CultureInfo culture = new CultureInfo("en-US");
                string[] names = culture.DateTimeFormat.AbbreviatedDayNames;
                resultado += names[DiaInicio - 1].ToLowerInvariant();
                if (DiaFim > 0)
                {
                    resultado += "-";
                    resultado += names[DiaFim - 1].ToLowerInvariant();
                }
            }
            resultado += "|";
            if (MesDiaInicio == 0) { resultado += "*"; }
            else
            {
                resultado += MesDiaInicio.ToString();
                if (MesDiaFim > 0)
                {
                    resultado += "-";
                    resultado += MesDiaFim.ToString();
                }
            }
            resultado += "|";
            if (MesInicio == 0) { resultado += "*"; }
            else
            {
                var culture = new CultureInfo("en-US");
                string[] names = culture.DateTimeFormat.AbbreviatedMonthNames;
                resultado += names[MesInicio - 1].ToLowerInvariant();
                if (MesFim > 0)
                {
                    resultado += "-";
                    resultado += names[MesFim - 1].ToLowerInvariant();
                }
            }

            return resultado;
        }

        public override bool Equals(object obj)
        {
            return obj.ToString() == this.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
