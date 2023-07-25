using GbLib.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.RabbitMQ
{
    public interface IRabbitMqPublisher
    {
        #region Methods
        void Init();
        Task PublishAsync<TEvent>(TEvent _event, ICorrelationContext context)
            where TEvent : IEvent;

        #endregion Methods
    }
}
