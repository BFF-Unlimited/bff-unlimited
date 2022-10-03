using Bff.Core.Framework.Handlers;
using Bff.WebApi.Services.Administrations.Requests.Dto;
using Bff.WebApi.Services.Administrations.Requests.Queries;

namespace Bff.WebApi.Services.Administrations.Handlers.QueryHandlers
{
    internal class GetCardsDataQueryHandler : AsyncQueryHandlerBase<GetCardsDataQuery>
    {
        protected override async Task<object> DoExecute(GetCardsDataQuery query) =>
            await Task.FromResult(new CardsDataDto
            {
                Absenties = new AbsentieDto[] { new AbsentieDto { LeerlingId = Guid.NewGuid(), StartDate = new DateTime(2022, 9, 28), EndDate = new DateTime(2022, 9, 28), Reason = "Jantje is gisteren keihard van het klimrek gevallen" } },
                JarigeLeerlingen = new LeerlingDto[] { new LeerlingDto { FirstName = "Jantje", LastName = "Jansen", DateOfBirth = DateTime.Now } },
                Koppelingen = new KoppelingDto[] { new KoppelingDto { Name = "Momento", Url = "https://www.momento.nl", LogoUrl = "https://www.momento.nl/logo" } },
                LaatstBekekenPaginas = new LaatstBekekenPaginaDto[]
                {
                    new LaatstBekekenPaginaDto{ Id = "permission://Groep.Overview", CategoryDescription = "Groep.Overview", Description = "Groepsoverzicht" },
                    new LaatstBekekenPaginaDto{ Id = "permission://Leerling.Overview", CategoryDescription = "Leerling.Overview", Description = "Leerlingenoverzicht" }
                },
                Notities = new NotitieDto[] { new NotitieDto { LeerlingId = Guid.NewGuid(), DateOfOccurrence = DateTime.Now, Description = "Jantje heeft de juffrouw geslagen" } }
            });
    }
}