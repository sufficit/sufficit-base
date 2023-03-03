﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class EndDestination : Destination
    {
        public const string ASTERISKCONTEXT = "sufficit-app-blackhole";

        public EndDestination(string extension)
        {
            Extension = extension;
        }

        public override string TypeName => typeof(EndDestination).Name;

        public override string? Title 
        { 
            get {
                switch (Extension)
                {
                    case "hangup": return "Desligar";
                    case "congestion": return "Congestionado";
                    case "busy": return "Ocupado";
                    case "musiconhold": return "Espera Eterna";
                    case "no-service": return "Fora de Serviço";
                    case "zapateller": return "Telemarketing";
                    case "ring": return "Chamando";
                    case "isolated": return "Isolado";
                    default: throw new InvalidCastException($"extension not recognized: {Extension}");
                }  
            }
        }

        public override string Asterisk => $"{ASTERISKCONTEXT},{Extension},1";

        public string Extension { get; }

        /// <summary>
        /// Returns all possible values
        /// </summary>
        public static IEnumerable<Destination> All { get; }
            = new List<Destination>(new[]{
                new EndDestination("hangup"),
                new EndDestination("congestion"),
                new EndDestination("busy"),
                new EndDestination("musiconhold"),
                new EndDestination("ring"),
                new EndDestination("zapateller"),
                new EndDestination("no-service"),
                new EndDestination("isolated")
            });

        /// <summary>
        /// Hangup, done, do nothing, just hangup 
        /// </summary>
        public static EndDestination HangUp => new EndDestination("hangup");

        /// <summary>
        /// Indicate Progress and Playtones, returns congestion without anwser the channel
        /// </summary>
        public static EndDestination Congestion => new EndDestination("congestion");

        /// <summary>
        /// Answer, wait, zap telemarketing, play "no-service" and hangup
        /// </summary>
        public static EndDestination NoService => new EndDestination("no-service");

        /// <summary>
        /// Don't Answer, play "ss-isolated" and hangup (1) "Unallocated (unassigned) number"
        /// </summary>
        public static EndDestination Isolated => new EndDestination("isolated");
    }
}
