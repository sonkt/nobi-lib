namespace GbLib.Base
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        #region Methods

        Task HandleAsync(TCommand command, ICorrelationContext context);

        #endregion Methods
    }
}