using Sufficit.Notification;
using System;

namespace Sufficit.Finance
{
    /// <summary>
    ///     BankSlip delayed notification event base information
    /// </summary>
    [NotificationEventCollection]
    public class BankSlipDelayedNEventBase : NotificationEvent, INotificationEvent
    {
        public override Guid Id { get; } = Guid.Parse(IDEVENT);

        public override string Title => TITLE;

        public const string IDEVENT = "019b7134-58c0-4487-a593-409ea2443aac";
        public const string TITLE = "Boleto Bancário em atraso";

        public override SubscribeMethod Method 
            => SubscribeMethod.ByContextId;
    }
}
