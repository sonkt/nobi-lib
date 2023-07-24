using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.Base.Helpers
{
    public static class ConvertDateTime
    {
        #region Methods

        public static DateTime? GetDateTimeFromunix(long? LastUpdate)
        {
            DateTime? date = null;

            if (LastUpdate != null)
            {
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                date = start.AddMilliseconds(LastUpdate.Value).ToLocalTime();
            }

            return date;
        }

        #endregion Methods
    }
    public abstract class Converter
    {
        #region Fields

        private readonly Guid _From;

        private readonly Guid _To;

        #endregion Fields

        #region Constructors

        internal Converter(Guid from, Guid to)
        {
            _From = from;
            _To = to;
        }

        #endregion Constructors

        #region Properties

        public Guid From
        {
            get { return _From; }
        }

        public Guid To
        {
            get { return _To; }
        }

        #endregion Properties

        #region Methods

        public abstract object Convert(object obj);

        #endregion Methods
    }
}
