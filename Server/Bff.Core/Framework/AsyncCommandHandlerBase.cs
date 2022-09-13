using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace Bff.Core.Framework
{
    public abstract class AsyncCommandHandlerBase<TCommand> : HandlerBase, IAsyncCommandHandler<TCommand> where TCommand : class
    {
        private const int LONG_RUNNING_COMMAND_WARNING_IN_MS = 1000;

        protected bool UseReadOnlySession { get; set; }

        protected bool DisableUnitOfWork { get; set; }

        public bool StartNewTransactionScope { get; set; }

        [DebuggerStepThrough]
        public async Task<object> HandleAsync(TCommand command)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                this.Logger!.Debug(this.GetType(), "Entering Handle");

                GuardHandler(command);

                if (!this.DisableUnitOfWork)
                {
                    //if (this.UseReadOnlySession)
                    //    this.UnitOfWork.SetReadOnly(true);

                    //this.UnitOfWork.Start(this.StartNewTransactionScope);
                }

                var result = await this.DoHandle(command);

                //if (!this.DisableUnitOfWork)
                //    await this.UnitOfWork.CommitAsync();

                this.Logger!.Debug(this.GetType(), "Exiting Handle. Total time {0} ms", stopwatch.ElapsedMilliseconds);

                if (stopwatch.ElapsedMilliseconds > LONG_RUNNING_COMMAND_WARNING_IN_MS)
                    this.Logger!.Warn(this.GetType(), "This command took a long time to complete. {0} ms.", stopwatch.ElapsedMilliseconds);

                return result;
            }
            catch (Exception e)
            {
                if (!e.Data.Contains("Handler"))
                    e.Data.Add("Handler", this.GetType().ToString());

                this.Logger!.Warn(this.GetType(), e, "Exception while handling command");
                this.Logger!.Error(e, e.Message);

                //if (!this.DisableUnitOfWork)
                //    await this.UnitOfWork.RollbackAsync();

                ExceptionDispatchInfo.Capture(e).Throw();
                throw; // Will never get here
            }
            finally
            {
                //this.UnitOfWork.Dispose();
            }
        }

        protected abstract Task<object> DoHandle(TCommand command);
    }
}
