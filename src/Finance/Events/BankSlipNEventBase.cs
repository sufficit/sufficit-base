using Sufficit.Notification;
using System;

namespace Sufficit.Finance
{
    /// <summary>
    ///     BankSlip notification event base information
    /// </summary>
    [NotificationEventCollection]
    public class BankSlipNEventBase : NotificationEvent, INotificationEvent
    {
        public override Guid Id { get; } = Guid.Parse(IDEVENT);

        public override string Title => TITLE;

        public const string IDEVENT = "46372bd8-3f33-42c1-9d7e-135b36083b40";
        public const string TITLE = "Boleto Bancário";

        public override SubscribeMethod Method
            => SubscribeMethod.ByContextId;
    }
}
