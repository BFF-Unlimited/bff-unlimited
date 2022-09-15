using Bff.Core.Framework.Exceptions;
using Bff.Core.Framework.RequestErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Bff.Core.Framework
{
    public class DefaultExceptionHandler : IExceptionHandler
    {
        public DefaultExceptionHandler(IOperationResultFactory resultFactory)
        {
            OperationResultFactory = resultFactory;
        }

        public IOperationResultFactory OperationResultFactory { get; }

        public IActionResult PerformGetOperation<TResult>(Func<TResult> operation) =>
            PerformOperation(operation, TransformGetOperationResult);

        public Task<IActionResult> PerformGetOperation<TResult>(Func<Task<TResult>> operation) =>
            PerformOperationAsync(operation, TransformGetOperationResult);

        public IActionResult PerformCreateOperation<TResult>(Func<TResult> operation) =>
            PerformOperation(operation, TransformCreateOperationResult);

        public IActionResult PerformUpdateOperation<TResult>(Func<TResult> operation) =>
            PerformOperation(operation, TransformUpdateOperationResult);

        public IActionResult PerformCreateOrUpdateOperation<TResult>(Func<TResult> operation) =>
            PerformOperation(operation, TransformCreateOrUpdateOperationResult);

        public IActionResult PerformDeleteOperation<TResult>(Func<TResult> operation) =>
            PerformOperation(operation, TransformDeleteOperationResult);

        public Task<IActionResult> PerformCreateOperation<TResult>(Func<Task<TResult>> operation) =>
            PerformOperationAsync(operation, TransformCreateOperationResult);

        public Task<IActionResult> PerformUpdateOperation<TResult>(Func<Task<TResult>> operation) =>
            PerformOperationAsync(operation, TransformUpdateOperationResult);

        public Task<IActionResult> PerformCreateOrUpdateOperation<TResult>(Func<Task<TResult>> operation) =>
            PerformOperationAsync(operation, TransformCreateOrUpdateOperationResult);

        public Task<IActionResult> PerformDeleteOperation<TResult>( Func<Task<TResult>> operation) =>
            PerformOperationAsync(operation, TransformDeleteOperationResult);

        public Task<IActionResult> PerformCommandOperation<TResult>(Func<Task<TResult>> operation) =>
            PerformOperationAsync(operation, TransformCommandOperationResult);
        public IActionResult PerformCommandOperation<TResult>(Func<TResult> operation) =>
            PerformOperation(operation, TransformCommandOperationResult);
        private static IActionResult TransformCreateOperationResult<TResult>(TResult result) =>
            new OkObjectResult(result);

        private static IActionResult TransformUpdateOperationResult<TResult>(TResult result) =>
            new OkObjectResult(result);

        private static IActionResult TransformGetOperationResult<TResult>(TResult result) =>
            result is IActionResult operationResult ? operationResult : new OkObjectResult(result);

        private static IActionResult TransformCreateOrUpdateOperationResult<TResult>(TResult result)
        {
            if (result is OkResult)
                return new OkObjectResult(result);

            return new OkObjectResult(result);
        }

        private static IActionResult TransformCommandOperationResult<TResult>(TResult result) =>
            new OkObjectResult(result);

        private static IActionResult TransformDeleteOperationResult<TResult>(TResult result) =>
            new OkObjectResult(result);

        private async Task<IActionResult> PerformOperationAsync<TResult>(Func<Task<TResult>> operation, Func<TResult, IActionResult> transformResult)
        {
            try
            {
                var result = await operation();

                return result == null ? OperationResultFactory.NoContent() : transformResult(result);
            }
            catch (UnprocessableEntityException e)
            {
                return OperationResultFactory.UnprocessableEntity(e);
            }
            catch (ResourceNotFoundException e)
            {
                return OperationResultFactory.NotFound(e);
            }
            catch (UnauthorizedException e)
            {
                return OperationResultFactory.Unauthorized(e);
            }
            catch (ForbiddenException e)
            {
                return OperationResultFactory.Forbidden(e);
            }
            catch (TooManyRequestsException e)
            {
                return OperationResultFactory.TooManyRequests(e);
            }
            catch (ArgumentNullException e)
            {
                return OperationResultFactory.ArgumentNull(e);
            }
            catch (ArgumentException e)
            {
                return OperationResultFactory.Argument(e);
            }
            catch (DataConflictException e)
            {
                return OperationResultFactory.DataConflict(e);
            }
            catch (OverflowException e)
            {
                return OperationResultFactory.Forbidden(new ForbiddenException("FRAMEWORK_OVERFLOW_ERRORMESSAGE", e));
            }
            catch (Exception)
            {
                return OperationResultFactory.InternalServerError();
            }
        }

        private IActionResult PerformOperation<TResult>(Func<TResult> operation, Func<TResult, IActionResult> transformResult)
        {
            try
            {
                var result = operation();
                return result == null ? OperationResultFactory.NoContent() : transformResult(result);
            }
            catch (UnprocessableEntityException e)
            {
                return OperationResultFactory.UnprocessableEntity(e);
            }
            catch (ResourceNotFoundException e)
            {
                return OperationResultFactory.NotFound(e);
            }
            catch (UnauthorizedException e)
            {
                return OperationResultFactory.Unauthorized(e);
            }
            catch (ForbiddenException e)
            {
                return OperationResultFactory.Forbidden(e);
            }
            catch (TooManyRequestsException e)
            {
                return OperationResultFactory.TooManyRequests(e);
            }
            catch (DataConflictException e)
            {
                return OperationResultFactory.DataConflict(e);
            }
            catch (ArgumentNullException e)
            {
                return OperationResultFactory.ArgumentNull(e);
            }
            catch (ArgumentException e)
            {
                return OperationResultFactory.Argument(e);
            }
            catch (OverflowException e)
            {
                return OperationResultFactory.Forbidden(new ForbiddenException("FRAMEWORK_OVERFLOW_ERRORMESSAGE", e));
            }
            catch (Exception)
            {
                return OperationResultFactory.InternalServerError();
            }
        }
    }
}
