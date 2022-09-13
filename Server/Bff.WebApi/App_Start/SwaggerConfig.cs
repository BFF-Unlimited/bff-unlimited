using Microsoft.OpenApi.Models;

namespace Bff.WebApi
{

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
