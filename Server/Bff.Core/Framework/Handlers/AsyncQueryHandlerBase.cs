using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace Bff.Core.Framework.Handlers
{
    public abstract class AsyncQueryHandlerBase<TQuery> : HandlerBase, IAsyncQueryHandler<TQuery> where TQuery : class
    {
        private const int LONG_RUNNING_QUERY_WARNING_IN_MS = 500;

        protected AsyncQueryHandlerBase()
        {
            UseReadOnlySession = true;
        }

        protected bool UseReadOnlySession { get; }

        [DebuggerStepThrough]
        public async Task<object> ExecuteAsync(TQuery query)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                Logger!.Debug(GetType(), "Entering Execute");

                GuardHandler(query);

                //UnitOfWork.SetReadOnly(UseReadOnlySession);
                //UnitOfWork.Start();

                var result = await DoExecute(query);

                //await UnitOfWork.CommitAsync();

                Logger.Debug(GetType(), "Exiting Execute. Total time {0} ms", stopwatch.ElapsedMilliseconds);

                if (stopwatch.ElapsedMilliseconds > LONG_RUNNING_QUERY_WARNING_IN_MS)
                    Logger.Warn(GetType(), "This query took a long time to complete. {0} ms.", stopwatch.ElapsedMilliseconds);

                return result;
            }
            catch (Exception e)
            {
                if (!e.Data.Contains("Handler"))
                    e.Data.Add("Handler", GetType().ToString());

                Logger!.Warn(GetType(), e, "Exception while executing query");
                Logger!.Error(e, e.Message);

                //await UnitOfWork.RollbackAsync();

                ExceptionDispatchInfo.Capture(e).Throw();
                throw; // Will never get here
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
        }

        protected abstract Task<object> DoExecute(TQuery query);
    }
}
