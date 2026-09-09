using System.Threading.Tasks;

namespace Sufficit.Logging
{
    /// <summary>
    ///     StopWatch to using log on database by provider <br />
    ///     For use at WebForms for now
    /// </summary>
    public class LogStopWatchBackground<TClass, TContent> : LogStopWatch<TClass, TContent>
    {
        /// <summary>
        ///     Default launcher
        /// </summary>
        public LogStopWatchBackground(ITrackLog provider, bool autoStart = true)
            : base (provider, autoStart) { }

        /// <summary>
        ///     Separating async method to afford overriding
        /// </summary>
        public override void Register()
            => Task.Run(base.Register);               
    }    
}
