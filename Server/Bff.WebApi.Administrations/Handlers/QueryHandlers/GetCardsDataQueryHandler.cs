using Bff.Core.Framework.Handlers;
using Bff.WebApi.Services.Administrations.Requests.Dto;
using Bff.WebApi.Services.Administrations.Requests.Queries;

namespace Bff.WebApi.Services.Administrations.Handlers.QueryHandlers
{
    internal class GetCardsDataQueryHandler : AsyncQueryHandlerBase<GetCardsDataQuery>
    {
        protected override async Task<object> DoExecute(GetCardsDataQuery query)
        {
            return await Task.FromResult(new CardsDataDto[]
            {

            });
        }
    }
}