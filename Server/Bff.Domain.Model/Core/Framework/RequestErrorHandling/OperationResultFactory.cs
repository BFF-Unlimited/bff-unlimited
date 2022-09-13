using Bff.Domain.Model.Core.Framework.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Bff.Domain.Model.Core.Framework.RequestErrorHandling
{
    public class OperationResultFactory : IOperationResultFactory
    {
        public OperationResultFactory()
        {
        }

        public IActionResult UnprocessableEntity(Exception e)
        {
            var ei = CreateExceptionInfo(e);

            return new ObjectResult(ei) { StatusCode = 422 };
        }
        public IActionResult Argument(ArgumentException e)
        {
            var ei = CreateExceptionInfo(e);
            return new ObjectResult(ei) { StatusCode = (int)HttpStatusCode.Forbidden };
        }
        public IActionResult ArgumentNull(ArgumentNullException e)
        {
            var ei = CreateExceptionInfo(e);

            return new ObjectResult(ei) { StatusCode = (int)HttpStatusCode.Forbidden };
        }

        public IActionResult DataConflict(DataConflictException e)
        {
            var ei = CreateExceptionInfo(e);
            return new ObjectResult(ei) { StatusCode = 409 };
        }

        public IActionResult NoContent() => new NoContentResult();

        public IActionResult NotFound(Exception e) => new ObjectResult(CreateExceptionInfo(e)) { StatusCode = (int)HttpStatusCode.NotFound };

        public IActionResult Unauthorized(Exception e) => new ObjectResult(CreateExceptionInfo(e)) { StatusCode = (int)HttpStatusCode.Unauthorized };

        public IActionResult InternalServerError() => new ObjectResult(null) { StatusCode = 500 };

        public IActionResult BadRequest(Exception e) => new ObjectResult(CreateExceptionInfo(e)) { StatusCode = (int)HttpStatusCode.BadRequest }; 

        public IActionResult Forbidden(ForbiddenException e)
        {
            var ei = CreateExceptionInfo(e);
            return new ObjectResult(ei) { StatusCode = (int)HttpStatusCode.Forbidden }; 
        }

        public IActionResult TooManyRequests(TooManyRequestsException e)
        {
            var ei = CreateExceptionInfo(e);

            return new ObjectResult(ei) { StatusCode = (int)429 };
        }

        public IActionResult Validation(ValidationException e) => new ObjectResult(CreateExceptionInfo(e)) { StatusCode = (int)HttpStatusCode.BadRequest }; 

        private static Exception CreateExceptionInfo(Exception e) => e;

    }
}
