﻿using Esis.Shin.Core.Framework.Handlers;
using Esis.Shin.Services.Administrations.Requests.Dto;
using Esis.Shin.Services.Administrations.Requests.Queries;

namespace Esis.Shin.Services.Administrations.Handlers.QueryHandlers
{
    internal class GetCardsDataQueryHandler : AsyncQueryHandlerBase<GetCardsDataQuery>
    {
        protected override async Task<object> DoExecute(GetCardsDataQuery query)
        {
            var result = new CardsDataDto();
            result.Absenties.Add(new AbsentieDto { LeerlingId = Guid.NewGuid(), StartDate = new DateTime(2022, 9, 28), EndDate = new DateTime(2022, 9, 28), Reason = "Jantje is gisteren keihard van het klimrek gevallen" });
            result.JarigeLeerlingen.Add(new LeerlingDto { FirstName = "Jantje", LastName = "Jansen", DateOfBirth = DateTime.Now });
            result.Koppelingen.Add(new KoppelingDto { Name = "Momento", Url = "https://www.momento.nl", LogoUrl = "https://www.momento.nl/logo" });
            result.LaatstBekekenPaginas.Add(new LaatstBekekenPaginaDto { Id = "permission://Groep.Overview", CategoryDescription = "Groep.Overview", Description = "Groepsoverzicht" });
            result.LaatstBekekenPaginas.Add(new LaatstBekekenPaginaDto { Id = "permission://Leerling.Overview", CategoryDescription = "Leerling.Overview", Description = "Leerlingenoverzicht" });
            result.Notities.Add(new NotitieDto { LeerlingId = Guid.NewGuid(), DateOfOccurrence = DateTime.Now, Description = "Jantje heeft de juffrouw geslagen" });

            return await Task.FromResult(result);
        }
    }
}