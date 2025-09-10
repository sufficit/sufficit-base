using System;

namespace Sufficit.Telephony
{
    /// <summary>
    ///     Exception thrown when a loop is detected in dial plan processing
    /// </summary>
    public class DialPlanLoopException : InvalidOperationException, IRequestException
    {
        public DialPlanLoopException() : base("Possível loop detectado no plano de entrada") 
        { 
        }

        public DialPlanLoopException(string? message) : base(message) 
        { 
        }

        public DialPlanLoopException(string? message, Exception? innerException) : base(message, innerException) 
        { 
        }

        public virtual string Title { get; } = "Loop no Plano de Discagem";

        public virtual string? Description { get; } = "Verifique se há configurações circulares em seu plano de discagem que possam estar causando um processamento infinito. O sistema limitou o processamento para proteger a interface.";
    }
}
