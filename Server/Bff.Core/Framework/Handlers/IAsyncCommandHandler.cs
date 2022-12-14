namespace Bff.Core.Framework.Handlers
{
    public interface IAsyncCommandHandler<in TCommand> : IHandler
        where TCommand : class
    {
        bool StartNewTransactionScope { get; set; }

        Task<object> HandleAsync(TCommand command);
    }
}
