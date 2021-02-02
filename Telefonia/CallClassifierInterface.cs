using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telefonia
{
    /// <summary>
    /// Interface utilizada para poder classificar uma chamada
    /// </summary>
    public interface CallClassifierInterface
    {
        /// <summary>
        /// Extensão que originou a chamada
        /// </summary>
        string Origin { get; }

        /// <summary>
        /// Extensão de destino dessa chamada
        /// </summary>
        string Destination { get; }
    }
}
