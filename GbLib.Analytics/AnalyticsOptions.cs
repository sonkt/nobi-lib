using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Analytics
{
    public class AnalyticsOptions
    {
        public string? OrgnizationCode { get; set; }
        public string? OrgnizationName { get; set; }
        public string? SecretKey { get; set; }
        public string? EndPointUri { get; set; }
    }
}
