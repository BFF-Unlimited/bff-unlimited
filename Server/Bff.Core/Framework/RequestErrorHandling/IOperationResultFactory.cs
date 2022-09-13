using Bff.Core.Framework.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bff.Core.Framework.RequestErrorHandling
{
    public interface IOperationResultFactory
    {
        IActionResult UnprocessableEntity(Exception e);

        IActionResult ArgumentNull(ArgumentNullException e);

        IActionResult Argument(ArgumentException e);

        IActionResult DataConflict(DataConflictException e);

        IActionResult NoContent();

        IActionResult NotFound(Exception e);

        IActionResult Unauthorized(Exception e);

        IActionResult InternalServerError();

        IActionResult BadRequest(Exception e);

        IActionResult Forbidden(ForbiddenException e);

        IActionResult TooManyRequests(TooManyRequestsException e);

        IActionResult Validation(ValidationException e);
    }
}
