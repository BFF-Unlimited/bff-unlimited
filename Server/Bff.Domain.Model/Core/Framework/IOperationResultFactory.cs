using Microsoft.AspNetCore.Mvc;

namespace Bff.Domain.Model.Core.Framework
{
    public interface IOperationResultFactory
    {
        IActionResult NoContent();
        IActionResult InternalServerError();
        IActionResult Forbidden(ForbiddenException e);
    }
}
