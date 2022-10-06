using Bff.Core.Framework.Handlers;
using Bff.WebApi.Services.Administrations.Requests.Dto;
using Bff.WebApi.Services.Administrations.Requests.Queries;

namespace Bff.WebApi.Services.Administrations.Handlers.QueryHandlers
{
    internal class GetActiveUserQueryHandler : AsyncQueryHandlerBase<GetActiveUserQuery>
    {
        protected override async Task<object> DoExecute(GetActiveUserQuery query)
        {
            var vestiging = new VestigingIdentificationDto("logoUrl", "Vestiging");
            var groep = new GroepIdentificationDto("Groep");
            var result = new UserDto
            {
                UserName = "Ans",
                ActiveVestiging = vestiging,
                ActiveGroep = groep
            };
            result.Vestigingen.Add(vestiging);
            result.Groepen.Add(groep);
            result.Permissions.Add(new PermissionDto("permission://Groep.Overview", "Groep.Overview", "Groepsoverzicht"));
            result.Permissions.Add(new PermissionDto("permission://Groep.Groepsplan", "Groep.Groepsplan", "Groepsplan"));
            result.Permissions.Add(new PermissionDto("permission://Groep.About", "Groep.About", "Over"));
            result.Permissions.Add(new PermissionDto("permission://Leerling.Overview", "Leerling.Overview", "Leerlingenoverzicht"));
            result.Permissions.Add(new PermissionDto("permission://Leerling.Search", "Leerling.Search", "Leerling zoeken"));
            result.Permissions.Add(new PermissionDto("permission://Registration.Overview", "Registration.Overview", "Registratieoverzicht"));
            result.Permissions.Add(new PermissionDto("permission://Registration.Create", "Registration.Create", "Registratie aanmaken"));
            
            return await Task.FromResult(result);
        }
    }
}