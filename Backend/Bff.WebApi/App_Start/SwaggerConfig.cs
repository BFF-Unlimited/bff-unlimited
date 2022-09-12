namespace Bff.WebApi
{
    public static class SwaggerConfig
    {
        public static void Configure(IServiceCollection service)
        {
            service.AddSwaggerGen();
        }
    }
}
