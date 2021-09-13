using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sufficit.Gateway.Receitanet
{
    public interface IRNDestination
    {
        string Title { get; }

        string Asterisk { get; }
    }
}
