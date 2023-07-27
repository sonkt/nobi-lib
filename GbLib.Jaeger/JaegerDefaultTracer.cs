using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using OpenTracing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Jaeger
{
    public class DefaultTracer
    {
        #region Methods

        public static ITracer Create()
            => new Tracer.Builder(Assembly.GetEntryAssembly()?.FullName)
                .WithReporter(new NoopReporter())
                .WithSampler(new ConstSampler(false))
                .Build();

        #endregion Methods
    }
}
