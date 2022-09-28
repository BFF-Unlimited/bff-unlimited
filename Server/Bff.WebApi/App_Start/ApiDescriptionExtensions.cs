using Microsoft.AspNetCore.Mvc.ApiExplorer;
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
}
