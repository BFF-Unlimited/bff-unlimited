using Esis.Shin.Core.Framework.Handlers;
using Esis.Shin.Services.Administrations.Requests.Dto;
using Esis.Shin.Services.Administrations.Requests.Queries;

namespace Esis.Shin.Services.Administrations.Handlers.QueryHandlers
{
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
}