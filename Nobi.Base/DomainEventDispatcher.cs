using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobi.Base
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        #region Fields

        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;

        #endregion Fields

        #region Constructors

        public DomainEventDispatcher(IMediator mediator, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _mediator = mediator;
        }

        #endregion Constructors

        #region Methods

        public async Task Dispatch(IEvent @event)
        {
            await _mediator.Publish(@event);
        }

        public void Dispose()
        {
        }

        #endregion Methods
    }
}
