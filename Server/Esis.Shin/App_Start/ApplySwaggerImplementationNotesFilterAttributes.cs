
using Esis.Shin.Core.Framework.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Esis.Shin
{
    internal class ApplySwaggerImplementationNotesFilterAttributes : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            foreach (var attr in context.ApiDescription.GetControllerAndActionAttributes<SwaggerImplementationNotesAttribute>())
            {
                operation.Description += attr.ImplementationNotes;
                operation.Description += "\r\n";
            }
        }
    }
}
