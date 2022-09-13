
using Bff.Domain.Model.Core.Framework.Attributes;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Bff.WebApi
{
    public static class ApiDescriptionExtensions
    {
        public static IEnumerable<TAttribute> GetControllerAndActionAttributes<TAttribute>(this ApiDescription apiDesc)
            where TAttribute : class
        {
            var result  = new List<TAttribute>();
            result.AddRange(apiDesc.CustomAttributes().Where(a => a.GetType().IsSubclassOf(typeof(TAttribute))).Cast<TAttribute>());
            MethodInfo methodInfo;
            if (apiDesc.TryGetMethodInfo(out methodInfo))
            {
                result.AddRange(methodInfo.GetCustomAttributes(typeof(TAttribute), false).Cast<TAttribute>());
            }

            return result;
        }
    }

    internal class ApplySwaggerImplementationNotesFilterAttributes : IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            foreach (var attr in context.ApiDescription.GetControllerAndActionAttributes<SwaggerImplementationNotesAttribute>())
            {
                operation.Description += attr.ImplementationNotes;
                operation.Description += "\r\n";
            }
        }
    }

    public static class SwaggerConfig
    {
        public static void Configure(IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.OperationFilter<ApplySwaggerImplementationNotesFilterAttributes>();
                c.DescribeAllParametersInCamelCase();
                c.AddSecurityDefinition("Bearer", //Name the security scheme
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                        Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()

                    }
                });

            });
        }
    }
}
