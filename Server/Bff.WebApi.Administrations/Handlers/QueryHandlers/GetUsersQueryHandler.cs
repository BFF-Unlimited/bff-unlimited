using Bff.Core.Framework.Handlers;
using Bff.WebApi.Services.Administrations.Requests.Dto;
using Bff.WebApi.Services.Administrations.Requests.Queries;

namespace Bff.WebApi.Services.Administrations.Handlers.QueryHandlers;

internal class GetUsersQueryHandler : QueryHandlerBase<GetUsersQuery>
{
    protected override UserIdentificationDto[] DoExecute(GetUsersQuery query)
    {
        return new UserIdentificationDto[]
        {
            new UserIdentificationDto("Ans"),
            new UserIdentificationDto("Willem")
        };
    }
}