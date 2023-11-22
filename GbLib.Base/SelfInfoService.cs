using System.Reflection;

namespace GbLib.Base
{
    public class SelfInfoService : ISelfInfoService
    {
        #region Constructors

        public SelfInfoService()
        {
            Id = NewGuid;
            Name = Assembly.GetEntryAssembly()?.GetName().Name;
        }

        #endregion Constructors

        #region Properties

        public string Id { get; }

        public string Name { get; }

        private static string NewGuid => $"{Guid.NewGuid():N}";

        #endregion Properties
    }
}