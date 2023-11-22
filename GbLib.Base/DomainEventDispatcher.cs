using MediatR;

namespace GbLib.Base
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