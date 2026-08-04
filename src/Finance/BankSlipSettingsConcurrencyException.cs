using System;

namespace Sufficit.Finance
{
    /// <summary>
    /// Indicates that tenant bank slip settings changed after the submitted version was read.
    /// </summary>
    public class BankSlipSettingsConcurrencyException : Exception
    {
        public BankSlipSettingsConcurrencyException()
            : base("Bank slip settings changed before this update was applied.")
        {
        }
    }
}
