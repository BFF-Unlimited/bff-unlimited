using System.Net;
using Esis.Shin.Core.Framework;
using Esis.Shin.Core.Framework.Handlers;
using Esis.Shin.Services.Administrations.DataAccess.Entities;
using Esis.Shin.Services.Administrations.Requests.Dto;
using Esis.Shin.Services.Administrations.Requests.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Esis.Shin.Services.Administrations.ApplicationServer
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CardsDataController : ControllerBase
    {
        private readonly IHandlerFactory _handlerFactory;
        private readonly IExceptionHandler _exceptionHandler;

        public CardsDataController(IHandlerFactory handlerFactory, IExceptionHandler exceptionHandler)
        {
            _handlerFactory = handlerFactory;
            _exceptionHandler = exceptionHandler;
        }

        [HttpGet(Name = "GetCardsData")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CardsDataDto))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Er ging iets fout")]
        public async Task<IActionResult> GetCardsData()
        {
            var query = new GetCardsDataQuery();

            var handler = _handlerFactory.GetAsyncQueryHandler<GetCardsDataQuery>();

            return await _exceptionHandler.PerformGetOperation(() => handler.ExecuteAsync(query));
        }
    }
}