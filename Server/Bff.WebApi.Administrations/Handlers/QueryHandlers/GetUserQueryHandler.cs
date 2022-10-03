using Bff.Core.Framework.Handlers;
using Bff.WebApi.Services.Administrations.Requests.Dto;
using Bff.WebApi.Services.Administrations.Requests.Queries;

namespace Bff.WebApi.Services.Administrations.Handlers.QueryHandlers
{
    internal class GetUserQueryHandler : AsyncQueryHandlerBase<GetUserQuery>
    {
        protected override async Task<object> DoExecute(GetUserQuery query)
        {
            var vestiging = new VestigingIdentificationDto("logoUrl", "Vestiging");
            var groep = new GroepIdentificationDto("Groep");

            return await Task.FromResult(new UserDto(
                userName: "Ans",
                activeVestiging: vestiging,
                activeGroep: groep,
                vestigingen: new[] { vestiging },
                groepen: new[] { groep },
                permissions: new[]
                {
                    new PermissionDto("permission://Groep.Overview", "Groep.Overview", "Groepsoverzicht"),
                    new PermissionDto("permission://Groep.Groepsplan", "Groep.Groepsplan", "Groepsplan"),
                    new PermissionDto("permission://Groep.About", "Groep.About", "Over"),
                    new PermissionDto("permission://Leerling.Overview", "Leerling.Overview", "Leerlingenoverzicht"),
                    new PermissionDto("permission://Leerling.Search", "Leerling.Search", "Leerling zoeken"),
                    new PermissionDto("permission://Registration.Overview", "Registration.Overview", "Registratieoverzicht"),
                    new PermissionDto("permission://Registration.Create", "Registration.Create", "Registratie aanmaken")
                }));
        }
    }
}