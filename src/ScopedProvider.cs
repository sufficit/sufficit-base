using Microsoft.Extensions.DependencyInjection;

namespace Sufficit
{
    /// <summary>
    ///    This provider will use a new scope for each instance and dispose it when the object is disposed
    /// </summary>
    public abstract class ScopedProvider
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ScopedProvider(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        #region INTERFACE 

        protected IServiceScope CreateScope()
            => _serviceScopeFactory.CreateScope();

        protected AsyncServiceScope CreateAsyncScope()
            => _serviceScopeFactory.CreateAsyncScope();

        #endregion
    }    
}
