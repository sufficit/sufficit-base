using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    public class EndDestination : Destination
    {
        public const string ASTERISKCONTEXT = "app-blackhole";

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
                    default: return "Desconhecido";
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
                new EndDestination("no-service")
            });
    }
}
