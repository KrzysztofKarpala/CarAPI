using ConsumerApi2.Application.Dto;
using ConsumerApi2.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConsumerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<MessageCarDto>>> GetAllRecievedMessagesAsync()
        {
            var getRecievedMessageQuery = new GetRecievedMessageQuery();
            var queryResponse = await _mediator.Send(getRecievedMessageQuery);
            return Ok(queryResponse);
        }
    }
}
