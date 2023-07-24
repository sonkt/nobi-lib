using Serilog.Events;
using Serilog.Formatting.Elasticsearch;

namespace Nobi.Loging
{
    public class ElasticsearchJsonFormatterRendered : ElasticsearchJsonFormatter
    {
        #region Methods

        protected override void WriteLevel(LogEventLevel level, ref string delim, TextWriter output)
        {
            var intLevel = (int)level;
            WriteJsonProperty("level", intLevel, ref delim, output);
        }

        #endregion Methods
    }
}
