using Bff.Domain.Model.Core.Framework.Exceptions;
using Bff.Domain.Model.Core.Framework.RequestErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace Bff.Domain.Model.Core.Framework
{
    public class DefaultExceptionHandler : IExceptionHandler
    {
        public DefaultExceptionHandler(IOperationResultFactory resultFactory)
        {
            this.OperationResultFactory = resultFactory;
        }

        public IOperationResultFactory OperationResultFactory { get; }

        public IActionResult PerformGetOperation<TResult>(Func<TResult> operation) =>
            this.PerformOperation(operation, TransformGetOperationResult);

        public Task<IActionResult> PerformGetOperation<TResult>(Func<Task<TResult>> operation) =>
            this.PerformOperationAsync(operation, TransformGetOperationResult);

        public IActionResult PerformCreateOperation<TResult>(Func<TResult> operation) =>
            this.PerformOperation(operation, TransformCreateOperationResult);

        public IActionResult PerformUpdateOperation<TResult>(Func<TResult> operation) =>
            this.PerformOperation(operation, TransformUpdateOperationResult);

        public IActionResult PerformCreateOrUpdateOperation<TResult>(Func<TResult> operation) =>
            this.PerformOperation(operation, TransformCreateOrUpdateOperationResult);

        public IActionResult PerformDeleteOperation<TResult>(Func<TResult> operation) =>
            this.PerformOperation(operation, TransformDeleteOperationResult);

        public Task<IActionResult> PerformCreateOperation<TResult>(Func<Task<TResult>> operation) =>
            this.PerformOperationAsync(operation, TransformCreateOperationResult);

        public Task<IActionResult> PerformUpdateOperation<TResult>(Func<Task<TResult>> operation) =>
            this.PerformOperationAsync(operation, TransformUpdateOperationResult);

        public Task<IActionResult> PerformCreateOrUpdateOperation<TResult>(Func<Task<TResult>> operation) =>
            this.PerformOperationAsync(operation, TransformCreateOrUpdateOperationResult);

        public Task<IActionResult> PerformDeleteOperation<TResult>( Func<Task<TResult>> operation) =>
            this.PerformOperationAsync(operation, TransformDeleteOperationResult);

        public Task<IActionResult> PerformCommandOperation<TResult>(Func<Task<TResult>> operation) =>
            this.PerformOperationAsync(operation, TransformCommandOperationResult);
        public IActionResult PerformCommandOperation<TResult>(Func<TResult> operation) =>
            this.PerformOperation(operation, TransformCommandOperationResult);


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

                return result == null ? this.OperationResultFactory.NoContent() : transformResult(result);
            }
            catch (UnprocessableEntityException e)
            {
                return this.OperationResultFactory.UnprocessableEntity(e);
            }
            catch (ResourceNotFoundException e)
            {
                return this.OperationResultFactory.NotFound(e);
            }
            catch (UnauthorizedException e)
            {
                return this.OperationResultFactory.Unauthorized(e);
            }
            catch (ForbiddenException e)
            {
                return this.OperationResultFactory.Forbidden(e);
            }
            catch (TooManyRequestsException e)
            {
                return this.OperationResultFactory.TooManyRequests(e);
            }
            catch (ArgumentNullException e)
            {
                return this.OperationResultFactory.ArgumentNull(e);
            }
            catch (ArgumentException e)
            {
                return this.OperationResultFactory.Argument(e);
            }
            catch (DataConflictException e)
            {
                return this.OperationResultFactory.DataConflict(e);
            }
            catch (OverflowException e)
            {
                return this.OperationResultFactory.Forbidden(new ForbiddenException("FRAMEWORK_OVERFLOW_ERRORMESSAGE", e));
            }
            catch (Exception)
            {
                return this.OperationResultFactory.InternalServerError();
            }
        }

        private IActionResult PerformOperation<TResult>(Func<TResult> operation, Func<TResult, IActionResult> transformResult)
        {
            try
            {
                var result = operation();
                return result == null ? this.OperationResultFactory.NoContent() : transformResult(result);
            }
            catch (UnprocessableEntityException e)
            {
                return this.OperationResultFactory.UnprocessableEntity(e);
            }
            catch (ResourceNotFoundException e)
            {
                return this.OperationResultFactory.NotFound(e);
            }
            catch (UnauthorizedException e)
            {
                return this.OperationResultFactory.Unauthorized(e);
            }
            catch (ForbiddenException e)
            {
                return this.OperationResultFactory.Forbidden(e);
            }
            catch (TooManyRequestsException e)
            {
                return this.OperationResultFactory.TooManyRequests(e);
            }
            catch (DataConflictException e)
            {
                return this.OperationResultFactory.DataConflict(e);
            }
            catch (ArgumentNullException e)
            {
                return this.OperationResultFactory.ArgumentNull(e);
            }
            catch (ArgumentException e)
            {
                return this.OperationResultFactory.Argument(e);
            }
            catch (OverflowException e)
            {
                return this.OperationResultFactory.Forbidden(new ForbiddenException("FRAMEWORK_OVERFLOW_ERRORMESSAGE", e));
            }
            catch (Exception)
            {
                return this.OperationResultFactory.InternalServerError();
            }
        }
    }
}
