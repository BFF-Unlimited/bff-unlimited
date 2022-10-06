﻿using Esis.Shin.Core.Framework.Handlers;
using Esis.Shin.Services.Administrations.Requests.Dto;
using Esis.Shin.Services.Administrations.Requests.Queries;

namespace Esis.Shin.Services.Administrations.Handlers.QueryHandlers
{
    internal class GetUserQueryHandler : AsyncQueryHandlerBase<GetUserQuery>
    {
        protected override async Task<object> DoExecute(GetUserQuery query)
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