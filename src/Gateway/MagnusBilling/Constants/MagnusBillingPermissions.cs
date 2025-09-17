namespace Sufficit.Gateway.MagnusBilling
{
    /// <summary>
    /// Available permissions for MagnusBilling API keys
    /// </summary>
    public static class MagnusBillingPermissions
    {
        public const string USER_READ = "user_read";
        public const string USER_WRITE = "user_write";
        public const string CALL_READ = "call_read";
        public const string CALL_WRITE = "call_write";
        public const string BILLING_READ = "billing_read";
        public const string BILLING_WRITE = "billing_write";
        public const string RATE_READ = "rate_read";
        public const string RATE_WRITE = "rate_write";
        public const string PLAN_READ = "plan_read";
        public const string PLAN_WRITE = "plan_write";
        public const string SIP_READ = "sip_read";
        public const string SIP_WRITE = "sip_write";
        public const string TRUNK_READ = "trunk_read";
        public const string TRUNK_WRITE = "trunk_write";
        public const string DID_READ = "did_read";
        public const string DID_WRITE = "did_write";
        public const string REPORT_READ = "report_read";
        public const string ADMIN_ACCESS = "admin_access";

        public static readonly string[] AllPermissions = new[]
        {
            USER_READ, USER_WRITE,
            CALL_READ, CALL_WRITE,
            BILLING_READ, BILLING_WRITE,
            RATE_READ, RATE_WRITE,
            PLAN_READ, PLAN_WRITE,
            SIP_READ, SIP_WRITE,
            TRUNK_READ, TRUNK_WRITE,
            DID_READ, DID_WRITE,
            REPORT_READ,
            ADMIN_ACCESS
        };

        public static readonly string[] ReadOnlyPermissions = new[]
        {
            USER_READ, CALL_READ, BILLING_READ, RATE_READ,
            PLAN_READ, SIP_READ, TRUNK_READ, DID_READ, REPORT_READ
        };

        public static readonly string[] WritePermissions = new[]
        {
            USER_WRITE, CALL_WRITE, BILLING_WRITE, RATE_WRITE,
            PLAN_WRITE, SIP_WRITE, TRUNK_WRITE, DID_WRITE
        };
    }
}