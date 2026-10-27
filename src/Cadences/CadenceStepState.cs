namespace Sufficit.Cadences
{
    public enum CadenceStepState : byte
    {
        /// <summary>Date not reached yet.</summary>
        Upcoming = 0,

        /// <summary>Date reached; the action applies.</summary>
        Reached = 1,

        /// <summary>Date reached but the step condition excluded it.</summary>
        Skipped = 2,

        /// <summary>Resolved before the date; the step will never run.</summary>
        Cancelled = 3
    }
}
