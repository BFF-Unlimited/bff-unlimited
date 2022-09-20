using System.Net;
using Bff.Core.Framework;
using Bff.Core.Framework.Handlers;
using Bff.WebApi.Services.Administrations.Requests.Dto;
using Bff.WebApi.Services.Administrations.Requests.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bff.WebApi.Services.Administrations.ApplicationServer
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IHandlerFactory _handlerFactory;
        private readonly IExceptionHandler _exceptionHandler;

        public UserController(IHandlerFactory handlerFactory, IExceptionHandler exceptionHandler)
        {
            _handlerFactory = handlerFactory;
            _exceptionHandler = exceptionHandler;
        }

        [HttpGet(template: "{id}", Name = "GetUser")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UserDto))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Er ging iets fout")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var query = new GetUserQuery { UserId = id };

            var handler = _handlerFactory.GetAsyncQueryHandler<GetUserQuery>();

            return await _exceptionHandler.PerformGetOperation(() => handler.ExecuteAsync(query));
        }

        [HttpGet(template: "activeUser", Name = "GetActiveUser")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UserDto))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Er ging iets fout")]
        public async Task<IActionResult> GetActiveUser()
        {
            var query = new GetActiveUserQuery();

            var handler = _handlerFactory.GetAsyncQueryHandler<GetActiveUserQuery>();

            return await _exceptionHandler.PerformGetOperation(() => handler.ExecuteAsync(query));
        }

        [HttpGet(Name = "GetUsers")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IList<UserIdentificationDto>))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Er ging iets fout")]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();

            var handler = _handlerFactory.GetAsyncQueryHandler<GetUsersQuery>();

            return await _exceptionHandler.PerformGetOperation(() => handler.ExecuteAsync(query));
        }
    }
}