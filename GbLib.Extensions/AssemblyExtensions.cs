using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace GbLib.Extensions
{
    public static class AssemblyExtensions
    {
        #region Methods

        public static Assembly FindAssemblyBy(this string assemblyName)
        {
            var deps = DependencyContext.Default;
            var res = deps.CompileLibraries.Where(d => d.Name.Contains(assemblyName)).ToList();
            var assembly = Assembly.Load(new AssemblyName(res.First().Name));
            return assembly;
        }

        public static HashSet<Assembly> GetAssembliesByTypes(this IEnumerable<Type> types)
        {
            return new HashSet<Assembly>(types.Select(type => type.GetTypeInfo().Assembly));
        }

        #endregion Methods
    }
}