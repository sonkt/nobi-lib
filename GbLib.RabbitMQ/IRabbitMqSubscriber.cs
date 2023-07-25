using GbLib.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.RabbitMQ
{
    public interface IRabbitMqSubscriber
    {
        #region Methods

        IRabbitMqSubscriber SubscribeEvent<TEvent>()
            where TEvent : IEvent;

        #endregion Methods
    }
}
