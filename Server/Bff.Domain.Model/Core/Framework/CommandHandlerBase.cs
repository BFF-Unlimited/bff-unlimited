using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace Bff.Domain.Model.Core.Framework
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

                this.Logger.Debug(this.GetType(), "Entering Handle");

                GuardHandler(command);


                if (!this.DisableUnitOfWork)
                {
                    //if (this.UseReadOnlySession)
                    //    this.UnitOfWork.SetReadOnly(true);

                    //this.UnitOfWork.Start(this.StartNewTransactionScope);
                }

                this.AssertHasAccess();

                var result = this.DoHandle(command);

                //if (!this.DisableUnitOfWork)
                //    this.UnitOfWork.Commit();

                this.Logger.Debug(this.GetType(), "Exiting Handle. Total time {0} ms", stopwatch.ElapsedMilliseconds);

                if (stopwatch.ElapsedMilliseconds > LONG_RUNNING_COMMAND_WARNING_IN_MS)
                    this.Logger.Warn(this.GetType(), "This command took a long time to complete. {0} ms.", stopwatch.ElapsedMilliseconds);

                return result;
            }
            catch (Exception e)
            {
                if (!e.Data.Contains("Handler"))
                    e.Data.Add("Handler", this.GetType().ToString());

                this.Logger.Error(e, e.Message);

                this.Logger.Warn(this.GetType(), e, "Exception while handling command");

                //if (!this.DisableUnitOfWork)
                //    this.UnitOfWork.Rollback();

                ExceptionDispatchInfo.Capture(e).Throw();
                throw; // Will never get here
            }
            finally
            {
                //this.UnitOfWork.Dispose();
            }
        }

        protected abstract object DoHandle(TCommand command);
    }
}
