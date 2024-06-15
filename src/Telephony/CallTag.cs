using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony
{
    [JsonConverter(typeof(JsonCallTagConverter))]
    public class CallTag
    {
        private CallTag (string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("invalid empty string to call tag");

            // lowering by default use, database and asterisk
            Value = value.ToLowerInvariant().Trim();
        }

        public string Value { get; private set; }

        public override string ToString()
            => Value;

        public override bool Equals(object? obj)
            => obj?.ToString() == Value;
        
        public override int GetHashCode()
            => Value.GetHashCode();

        public static implicit operator string (CallTag tag) { return tag.Value; }

        /// <summary>
        /// Converts string to calltag
        /// </summary>
        /// <param name="tag">case insensivity</param>
        public static implicit operator CallTag(string tag)
        {
            // to upper for compare
            switch (tag.ToUpper())
            {
                case BILLINGOUTTAG: return BillingOut;
                case BILLINGINTAG: return BillingIn;
                case IDENTIFIEDTAG: return Identified;

                case FREETRUNKTAG: return FreeTrunk;
                case FIXEDTRUNKTAG: return FixedTrunk;
                case MOBILETRUNKTAG: return MobileTrunk;
                case FLEXTRUNKTAG: return FlexTrunk;
                case SINGLETRUNKTAG: return SingleTrunk;
                default: return new CallTag(tag);
            }
        }

        #region VALUES

        const string TAGPREFIX = "SUFF";

        /// <summary>
        ///     Billed outbound calls 
        /// </summary>
        public static CallTag BillingOut { get; } = new CallTag(BILLINGOUTTAG);
        const string BILLINGOUTTAG = TAGPREFIX + "BILLINGOUT";

        /// <summary>
        ///     Billed inbound calls
        /// </summary>
        public static CallTag BillingIn { get; } = new CallTag(BILLINGINTAG);
        const string BILLINGINTAG = TAGPREFIX + "BILLINGIN";

        /// <summary>
        ///     Identified outbound calls (solicited by user)
        /// </summary>
        public static CallTag Identified { get; } = new CallTag(IDENTIFIEDTAG);
        const string IDENTIFIEDTAG = "TRUNKIDENTIFIED";

        public static CallTag FreeTrunk { get; } = new CallTag(FREETRUNKTAG);
        const string FREETRUNKTAG = TAGPREFIX + "-" + nameof(DialOutTrunkType.FREE);

        public static CallTag FixedTrunk { get; } = new CallTag(FIXEDTRUNKTAG);
        const string FIXEDTRUNKTAG = TAGPREFIX + "-" + nameof(DialOutTrunkType.FIXED);

        public static CallTag MobileTrunk { get; } = new CallTag(MOBILETRUNKTAG);
        const string MOBILETRUNKTAG = TAGPREFIX + "-" + nameof(DialOutTrunkType.MOBILE);

        public static CallTag FlexTrunk { get; } = new CallTag(FLEXTRUNKTAG);
        const string FLEXTRUNKTAG = TAGPREFIX + "-" + nameof(DialOutTrunkType.FLEX);

        public static CallTag SingleTrunk { get; } = new CallTag(SINGLETRUNKTAG);
        const string SINGLETRUNKTAG = TAGPREFIX + "-" + nameof(DialOutTrunkType.SINGLE);

        #endregion
    }
}
