using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony.FreePBX
{
    public class FreePBXEndDestination : Destination
    {
        public const string ASTERISKCONTEXT = "app-blackhole";

        public FreePBXEndDestination(string extension)
        {
            Extension = extension;
        }

        public override string TypeName => typeof(FreePBXEndDestination).Name;

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
                new FreePBXEndDestination("hangup"),
                new FreePBXEndDestination("congestion"),
                new FreePBXEndDestination("busy"),
                new FreePBXEndDestination("musiconhold"),
                new FreePBXEndDestination("ring"),
                new FreePBXEndDestination("zapateller"),
                new FreePBXEndDestination("no-service")
            });

        /// <summary>
        /// Hangup, done, do nothing, just hangup 
        /// </summary>
        public static FreePBXEndDestination HangUp => new FreePBXEndDestination("hangup");

        /// <summary>
        /// Indicate Progress and Playtones, returns congestion without anwser the channel
        /// </summary>
        public static FreePBXEndDestination Congestion => new FreePBXEndDestination("congestion");

        /// <summary>
        /// Answer, wait, zap telemarketing, play "no-service" and hangup
        /// </summary>
        public static FreePBXEndDestination NoService => new FreePBXEndDestination("no-service");
    }
}
