namespace Bff.Core.Framework.Handlers
{
    public interface ICommandHandler<in TCommand> : IHandler
            where TCommand : class
    {
        bool StartNewTransactionScope { get; set; }
        object Handle(TCommand command);
    }
}
