using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace Bff.Core.Framework.Handlers
{
    public abstract class QueryHandlerBase<TQuery> : HandlerBase, IQueryHandler<TQuery> where TQuery : class
    {
        private const int LONG_RUNNING_QUERY_WARNING_IN_MS = 500;

        protected QueryHandlerBase()
        {
            UseReadOnlySession = true;
        }

        protected bool UseReadOnlySession { get; set; }

        [DebuggerStepThrough]
        public object Execute(TQuery query)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                Logger!.Debug(GetType(), "Entering Execute");

                GuardHandler(query);

                //UnitOfWork.SetReadOnly(UseReadOnlySession);
                //UnitOfWork.Start();

                var result = DoExecute(query);

                //UnitOfWork.Commit(); 

                Logger!.Debug(GetType(), "Exiting Execute. Total time {0} ms", stopwatch.ElapsedMilliseconds);

                if (stopwatch.ElapsedMilliseconds > LONG_RUNNING_QUERY_WARNING_IN_MS)
                    Logger!.Warn(GetType(), "This query took a long time to complete. {0} ms.", stopwatch.ElapsedMilliseconds);

                return result;
            }
            catch (Exception e)
            {
                if (!e.Data.Contains("Handler"))
                    e.Data.Add("Handler", GetType().ToString());

                Logger!.Warn(GetType(), e, "Exception while executing query");
                Logger!.Error(e, e.Message);

                // UnitOfWork.Rollback();

                ExceptionDispatchInfo.Capture(e).Throw();
                throw; // Will never get here
            }
            finally
            {
                //UnitOfWork.Dispose();
            }
        }

        protected abstract object DoExecute(TQuery query);
    }
}
