using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Logging
{
    /// <summary>
    ///     StopWatch to using log on database by provider
    /// </summary>
    public class LogStopWatch<TClass, TContent> : GenericLogDiverged<TClass, TContent>, IDisposable, IAsyncDisposable
    {
        private readonly Stopwatch _stopwatch;

        protected readonly ITrackLog _tracker;

        public override TimeSpan? Duration { 
            get => _stopwatch.Elapsed; 
            set => throw new NotSupportedException(); 
        }

        #region CONSTRUTORES & DESCONSTRUTORES

        /// <summary>
        ///     Default launcher
        /// </summary>
        public LogStopWatch(ITrackLog tracker, bool autoStart = true)
        {
            _stopwatch = new Stopwatch();
            _tracker = tracker;
            if (autoStart) Start();
        }

        ~LogStopWatch() => Dispose(false);

        #endregion
        #region IMPLEMENTACAO IDISPOSABLE

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
                if (disposing)
                {
                    Stop();

                    if (!IsRegistered && !Exception)                    
                        Register();                    
                }
            }
        }

        /// <summary>
        ///     Indicates if an exception was throw on this thread
        /// </summary>
        private bool Exception
        {
            get
            {
                {
                    return
#if NETFRAMEWORK || NETCOREAPP3_1_OR_GREATER
                            // API not exposed till netcoreapp3.0
                            // https://github.com/dotnet/corefx/pull/31169
                            Marshal.GetExceptionPointers() != IntPtr.Zero ||
#endif
#pragma warning disable CS0618 // GetExceptionCode obsolete
                                        Marshal.GetExceptionCode() != 0
#pragma warning restore CS0618
                                        ;
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            await Task.CompletedTask;
            Dispose(true);
        }

        #endregion

        public long ElapsedMilliseconds 
            => _stopwatch.ElapsedMilliseconds;

        public void Start()
        {
            if (!_stopwatch.IsRunning)
            {
                if (Timestamp == DateTime.MinValue)
                    Timestamp = DateTime.UtcNow;

                _stopwatch.Start();
            }
        }

        public void Stop()
        {
            if (_stopwatch.IsRunning)
            {
                _stopwatch.Stop();
            }
        }

        public bool IsRegistered { get; private set; }

        /// <summary>
        ///     save into provider <br />
        ///     separating async method to afford overriding  <br />
        ///     cleanup content
        /// </summary>
        public virtual async void Register()
            => await RegisterAsync(CancellationToken.None).ConfigureAwait(false);

        /// <summary>
        ///     save into provider <br />
        ///     separating async method to afford overriding  <br />
        ///     cleanup content
        /// </summary>
        public virtual async Task RegisterAsync(CancellationToken cancellationToken)
        {
            if (!IsRegistered)
            {
                IsRegistered = true;
                Stop();

                var extracted = this.ToJsonLog();
                await _tracker.Register(extracted, cancellationToken);

                // unattach any content to garbage collector finalize then
                Content = default;
            }
        }
    }
}
