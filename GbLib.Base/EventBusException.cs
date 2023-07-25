using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base
{
    public class EventBusException : Exception
    {
        #region Constructors

        public EventBusException()
        {
        }

        public EventBusException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }

        public EventBusException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public EventBusException(string code)
        {
            Code = code;
        }

        public EventBusException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public EventBusException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        #endregion Constructors

        #region Properties

        public string Code { get; }

        #endregion Properties
    }
}
