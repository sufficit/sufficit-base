using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telefonia.Tempo
{
    public static class ToTimeIntervalExtension
    {
        public static Telephony.TimeInterval ToTimeInterval(this IntervaloBase source)
            => new Telephony.TimeInterval()
            {
                HourStart = Convert.ToUInt32(source.HoraInicio),
                HourEnd = Convert.ToUInt32(source.HoraFim),

                WeekDayStart = source.DiaInicio == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.DiaInicio)),
                WeekDayEnd = source.DiaFim == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.DiaFim)),

                MonthDayStart = source.MesDiaInicio == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.MesDiaInicio)),
                MonthDayEnd = source.MesDiaFim == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.MesDiaFim)),

                MonthStart = source.MesInicio == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.MesInicio)),
                MonthEnd = source.MesFim == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.MesFim)),
            };
    }
}
