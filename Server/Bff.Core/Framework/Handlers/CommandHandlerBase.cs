using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace Bff.Core.Framework.Handlers
{

    public abstract class CommandHandlerBase<TCommand> : HandlerBase, ICommandHandler<TCommand> where TCommand : class
    {
        private const int LONG_RUNNING_COMMAND_WARNING_IN_MS = 1000;

        protected bool UseReadOnlySession { get; set; }

        protected bool DisableUnitOfWork { get; set; }

        public bool StartNewTransactionScope { get; set; }

        [DebuggerStepThrough]
        public object Handle(TCommand command)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                Logger!.Debug(GetType(), "Entering Handle");

                GuardHandler(command);

                if (!DisableUnitOfWork)
                {
                    //if (UseReadOnlySession)
                    //    UnitOfWork.SetReadOnly(true);

                    //UnitOfWork.Start(StartNewTransactionScope);
                }

                var result = DoHandle(command);

                //if (!DisableUnitOfWork)
                //    UnitOfWork.Commit();

                Logger!.Debug(GetType(), "Exiting Handle. Total time {0} ms", stopwatch.ElapsedMilliseconds);

                if (stopwatch.ElapsedMilliseconds > LONG_RUNNING_COMMAND_WARNING_IN_MS)
                    Logger!.Warn(GetType(), "This command took a long time to complete. {0} ms.", stopwatch.ElapsedMilliseconds);

                return result;
            }
            catch (Exception e)
            {
                if (!e.Data.Contains("Handler"))
                    e.Data.Add("Handler", GetType().ToString());

                Logger!.Error(e, e.Message);

                Logger!.Warn(GetType(), e, "Exception while handling command");

                //if (!DisableUnitOfWork)
                //    UnitOfWork.Rollback();

                ExceptionDispatchInfo.Capture(e).Throw();
                throw; // Will never get here
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
        }

        protected abstract object DoHandle(TCommand command);
    }
}
