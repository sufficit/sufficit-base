using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telefonia.Tempo
{
    public static class ToTimeIntervalExtension
    {
        public static Telephony.TimeInterval ToTimeInterval(this IntervaloBase source)
        {
            uint? hourstart = source.HoraInicio == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.HoraInicio));
            uint? hourend = source.HoraFim == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.HoraFim));
            
            uint? weekdaystart = source.DiaInicio == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.DiaInicio));
            uint? weekdayend = source.DiaFim == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.DiaFim));
            if (weekdaystart.HasValue && !weekdayend.HasValue)
                weekdayend = weekdaystart;

            uint? monthdaystart = source.MesDiaInicio == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.MesDiaInicio));
            uint? monthdayend = source.MesDiaFim == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.MesDiaFim));
            if (monthdaystart.HasValue && !monthdayend.HasValue)
                monthdayend = monthdaystart;

            uint? monthstart = source.MesInicio == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.MesInicio));
            uint? monthend = source.MesFim == 0 ? null : new Nullable<uint>(Convert.ToUInt32(source.MesFim));
            if (monthstart.HasValue && !monthend.HasValue)
                monthend = monthstart;

            return new Telephony.TimeInterval()
            {
                HourStart = hourstart,
                HourEnd = hourend,

                WeekDayStart = weekdaystart,
                WeekDayEnd = weekdayend,

                MonthDayStart = monthdaystart,
                MonthDayEnd = monthdayend,

                MonthStart = monthstart,
                MonthEnd = monthend,
            };
        }
    }
}
