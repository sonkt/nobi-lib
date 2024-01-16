using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Analytics
{
    public class AnalyticData
    {
        public string? Title { get; set; }
        public string? ActionKey { get; set; }
        public string? ClientType { get; set; }
        public DateTime? ActionTime { get; set; }
        public string? Message { get; set; }
    }
}
