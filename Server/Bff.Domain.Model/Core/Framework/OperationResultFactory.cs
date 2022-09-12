using Microsoft.AspNetCore.Mvc;

namespace Bff.Domain.Model.Core.Framework
{
    public class OperationResultFactory : IOperationResultFactory
    {
        public IActionResult NoContent()
        {
            return new NoContentResult();
        }

        public IActionResult InternalServerError()
        {
            return new ObjectResult(500);
        }

        public IActionResult Forbidden(ForbiddenException e)
        {
            return new ForbidResult(e.Message);
        }
    }
}
