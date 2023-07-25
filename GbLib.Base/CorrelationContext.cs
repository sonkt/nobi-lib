using Newtonsoft.Json;

namespace GbLib.Base
{
    public class CorrelationContext : ICorrelationContext
    {
        #region Constructors

        public CorrelationContext()
        {
        }

        [JsonConstructor]
        private CorrelationContext(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        #endregion Constructors

        #region Properties

        public Guid CorrelationId { get; }

        #endregion Properties

        #region Methods

        public static ICorrelationContext Create(Guid id)
        {
            return new CorrelationContext(id);
        }

        #endregion Methods
    }
}
