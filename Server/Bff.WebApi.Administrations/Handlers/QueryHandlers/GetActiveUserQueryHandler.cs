using Bff.Core.Framework.Handlers;
using Bff.WebApi.Services.Administrations.Requests.Dto;
using Bff.WebApi.Services.Administrations.Requests.Queries;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Bff.WebApi.Services.Administrations.Handlers.QueryHandlers
{
    public class GetActiveUserQueryHandler : AsyncQueryHandlerBase<GetActiveUserQuery>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public GetActiveUserQueryHandler(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        protected override Task<object> DoExecute(GetActiveUserQuery query)
        {
            if(_contextAccessor?.HttpContext?.User?.Identity is not ClaimsIdentity user)
                return Task.FromResult(new object());
            var vestiging = new VestigingIdentificationDto("logoUrl", "Vestiging");
            var groep = new GroepIdentificationDto("Groep");

            return Task.FromResult((object)new UserDto(
                userName: user.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value ?? "",
                activeVestiging: vestiging,
                activeGroep: groep,
                vestigingen: new[] { vestiging },
                groepen: new[] { groep },
                permissions: new[] {
                    new PermissionDto("permission://Groep.Overview", "Groep.Overview", "Groepsoverzicht"),
                    new PermissionDto("permission://Groep.Groepsplan", "Groep.Groepsplan", "Groepsplan"),
                    new PermissionDto("permission://Groep.About", "Groep.About", "Over"),
                    new PermissionDto("permission://Leerling.Overview", "Leerling.Overview", "Leerlingenoverzicht"),
                    new PermissionDto("permission://Leerling.Search", "Leerling.Search", "Leerling zoeken"),
                    new PermissionDto("permission://Registration.Overview", "Registration.Overview", "Registratieoverzicht"),
                    new PermissionDto("permission://Registration.Create", "Registration.Create", "Registratie aanmaken")
                }));
            ;
        }
    }
}