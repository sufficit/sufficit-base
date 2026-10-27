using System;

namespace Sufficit.Cadences
{
    public sealed class CadenceStepOutcome
    {
        public CadenceStep Step { get; set; } = new();

        public DateTime Date { get; set; }

        public CadenceStepState State { get; set; }

        public string? Reason { get; set; }
    }
}
