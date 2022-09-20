using Bff.Core.Framework.Handlers;
using Bff.WebApi.Services.Administrations.Requests.Dto;
using Bff.WebApi.Services.Administrations.Requests.Queries;

namespace Bff.WebApi.Services.Administrations.Handlers.QueryHandlers;

internal class GetUsersQueryHandler : AsyncQueryHandlerBase<GetUsersQuery>
{
    protected override async Task<object> DoExecute(GetUsersQuery query)
    {
        return await Task.FromResult(new UserIdentificationDto[]
        {
            new UserIdentificationDto("Ans"),
            new UserIdentificationDto("Willem")
        });
    }
}