using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Reports
{
    public class ReportParametersDictionary : Dictionary<string, string>, IReportParameters
    {
        public const string IDCONTEXT = "IDContext";
        public const string DTSTART = "DTStart";
        public const string DTEND = "DTEnd";

        public Guid IDContext
        {
            get
            {
                if (ContainsKey(IDCONTEXT))
                    return Guid.Parse(this[IDCONTEXT]);
                else return default;
            }
            set
            {
                if (ContainsKey(IDCONTEXT))
                    this[IDCONTEXT] = value.ToString();                
                else
                    Add(IDCONTEXT, value.ToString());
            }
        }

        public DateTime DTStart
        {
            get
            {
                if (ContainsKey(DTSTART))
                    return DateTime.Parse(this[DTSTART]);
                else return default;
            }
            set
            {
                if (ContainsKey(DTSTART))
                    this[DTSTART] = value.ToString("o");
                else
                    Add(DTSTART, value.ToString("o"));
            }
        }

        public DateTime DTEnd
        {
            get
            {
                if (ContainsKey(DTEND))
                    return DateTime.Parse(this[DTEND]);
                else return default;
            }
            set
            {
                if (ContainsKey(DTEND))
                    this[DTEND] = value.ToString("o");
                else
                    Add(DTEND, value.ToString("o"));
            }
        }

        public ReportParametersDictionary() { }

        public ReportParametersDictionary(IEnumerable<KeyValuePair<string, string>> keyValuePairs)
        {
            foreach (KeyValuePair<string, string> entry in keyValuePairs)
                Add(entry.Key, entry.Value);
        }      
    }
}
