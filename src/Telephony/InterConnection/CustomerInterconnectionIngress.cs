using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Sufficit.Telephony.InterConnection.PJSIP;

namespace Sufficit.Telephony.InterConnection
{
    public static class CustomerInterconnectionIngress
    {
        public const string Context = "from-interconnections";
        public const string Variable = "SUFFICIT_INTERCONNECTION_ROUTE";

        public static bool Eligible(Interconnection item) =>
            item.ContextId.GetValueOrDefault() != Guid.Empty &&
            (item.Direction == InterconnectionDirection.Inbound || item.Direction == InterconnectionDirection.Both) &&
            string.Equals(item.Technology, "PJSIP", StringComparison.OrdinalIgnoreCase);

        public static bool IsConfigured(Interconnection item) =>
            Eligible(item) && !string.IsNullOrEmpty(item.InboundDestination);

        public static bool ValidDestination(string? route) =>
            route != null && route.Length <= 150 &&
            Regex.IsMatch(route, @"\A[a-zA-Z0-9_-]+,[a-zA-Z0-9_*+#.-]+,[1-9][0-9]*\z");

        public static string ResolveContext(Interconnection item)
        {
            if (IsConfigured(item)) return Context;
            if (!string.IsNullOrEmpty(item.EndpointContext)) return item.EndpointContext;
            return string.IsNullOrEmpty(item.InboundProfile) ? "customer-default" : item.InboundProfile;
        }

        public static void Apply(PJSIPEndPoint endpoint, Interconnection item)
        {
            if (!IsConfigured(item) || !ValidDestination(item.InboundDestination)) return;
            if (!item.Registrations.Any(registration => registration.Enabled && registration.DeletedAtUtc == null &&
                    string.Equals(registration.EndpointRef, endpoint.id, StringComparison.Ordinal))) return;
            endpoint.context = Context;
            endpoint.accountcode = item.ContextId.GetValueOrDefault().ToString("N");
            endpoint.set_var = Variable + "=" + string.Join("|", endpoint.id, item.Id.ToString("N"),
                endpoint.accountcode, item.ChannelLimit.ToString(CultureInfo.InvariantCulture),
                item.InboundDestination!.Replace(',', '|'));
        }
    }
}
