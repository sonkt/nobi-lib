namespace GbLib.Base.Helpers
{
    using System;

    /// <summary>
    /// Defines the <see cref="IdHelper" />.
    /// </summary>
    public static class IdHelper
    {
        #region Methods

        public static Guid GenerateId(string guid = "")
        {
            return string.IsNullOrEmpty(guid) ? Guid.NewGuid() : new Guid(guid);
        }

        #endregion Methods
    }
}