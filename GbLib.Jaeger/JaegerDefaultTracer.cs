using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using OpenTracing;
using System.Reflection;

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