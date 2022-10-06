using Esis.Shin.Core.Framework.RequestErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Esis.Shin.Core.Framework
{
    public interface IExceptionHandler
    {
        IOperationResultFactory OperationResultFactory { get; }

        IActionResult PerformGetOperation<TResult>(Func<TResult> operation);

        IActionResult PerformCreateOperation<TResult>(Func<TResult> operation);

        IActionResult PerformUpdateOperation<TResult>(Func<TResult> operation);

        /// <summary>
        /// Use only in case when PUT method can be used for creating entities (e.g. relation logo, contact photo, article image)
        /// </summary>
        IActionResult PerformCreateOrUpdateOperation<TResult>(Func<TResult> operation);

        IActionResult PerformDeleteOperation<TResult>(Func<TResult> operation);

        Task<IActionResult> PerformGetOperation<TResult>(Func<Task<TResult>> operation);

        Task<IActionResult> PerformCreateOperation<TResult>(Func<Task<TResult>> operation);

        Task<IActionResult> PerformUpdateOperation<TResult>(Func<Task<TResult>> operation);

        /// <summary>
        /// Use only in case when PUT method can be used for creating entities (e.g. relation logo, contact photo, article image)
        /// </summary>
        Task<IActionResult> PerformCreateOrUpdateOperation<TResult>(Func<Task<TResult>> operation);

        Task<IActionResult> PerformDeleteOperation<TResult>(Func<Task<TResult>> operation);
    }
}
