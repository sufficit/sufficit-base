namespace Sufficit.Logging
{
    /// <summary>
    ///   Tracking interface for measuring status and statistics
    /// </summary>
    public interface ITracking
    {
        /// <summary>
        ///  Stop Watch Generic Log
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TContent"></typeparam>
        /// <returns></returns>
        LogStopWatch<TClass, TContent> Track<TClass, TContent>();

        /// <summary>
        ///   Stop Watch Json Log in background (Just for WebForms) uses Task.Run
        /// </summary>
        LogStopWatchBackground<TClass, TContent> TrackBackground<TClass, TContent>();
    }
}