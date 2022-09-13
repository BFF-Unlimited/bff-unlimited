using Bff.Core.Framework.Extensions;
using Ninject;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Bff.Core.Framework
{
    public abstract class QueryHandlerBase<TQuery> : HandlerBase, IQueryHandler<TQuery> where TQuery : class
    {
        private const int LONG_RUNNING_QUERY_WARNING_IN_MS = 500;

        protected QueryHandlerBase()
        {
            this.UseReadOnlySession = true;
        }

        protected bool UseReadOnlySession { get; set; }

        [DebuggerStepThrough]
        public object Execute(TQuery query)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();

                this.Logger!.Debug(this.GetType(), "Entering Execute");

                GuardHandler(query);

                //this.UnitOfWork.SetReadOnly(this.UseReadOnlySession);
                //this.UnitOfWork.Start();

                var result = this.DoExecute(query);

                //this.UnitOfWork.Commit(); 

                this.Logger!.Debug(this.GetType(), "Exiting Execute. Total time {0} ms", stopwatch.ElapsedMilliseconds);

                if (stopwatch.ElapsedMilliseconds > LONG_RUNNING_QUERY_WARNING_IN_MS)
                    this.Logger!.Warn(this.GetType(), "This query took a long time to complete. {0} ms.", stopwatch.ElapsedMilliseconds);

                return result;
            }
            catch (Exception e)
            {
                if (!e.Data.Contains("Handler"))
                    e.Data.Add("Handler", this.GetType().ToString());

                this.Logger!.Warn(this.GetType(), e, "Exception while executing query");
                this.Logger!.Error(e, e.Message);


                // this.UnitOfWork.Rollback();

                ExceptionDispatchInfo.Capture(e).Throw();
                throw; // Will never get here
            }
            finally
            {
                //this.UnitOfWork.Dispose();
            }
        }

        protected abstract object DoExecute(TQuery query);
    }
}
