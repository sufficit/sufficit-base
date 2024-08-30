using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Telephony
{
    /// <summary>
    /// To Do ! Create a unique id for each end destination
    /// </summary>
    public class EndDestination : Destination, IFriendly
    {
        public const string ASTERISKCONTEXT = "sufficit-app-blackhole";
        public const string FRIENDLYNAME = "Finalizar";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion

        public EndDestination(string extension)
        {
            Extension = extension;
        }

        public override string TypeName => nameof(EndDestination);

        public override string Title
        {
            get => Extension switch
            {
                "hangup" => "Desligar",
                "congestion" => "Congestionado",
                "busy" => "Ocupado",
                "musiconhold" => "Espera Eterna",
                "no-service" => "Fora de Serviço",
                "zapateller" => "Telemarketing",
                "ring" => "Chamando",
                "isolated" => "Isolado",
                _ => throw new InvalidCastException($"extension not recognized: {Extension}"),
            };
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
