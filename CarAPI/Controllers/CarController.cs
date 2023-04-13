using CarAPI.Application.Client;
using CarAPI.Application.Commands;
using CarAPI.Application.Dto;
using CarAPI.Application.Queries;
using CarAPI.Core.Repository;
using CarAPI.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly IMediator _mediator;

        public CarController(ILogger<CarController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all responses from database
        /// </summary>
        /// <returns></returns>

        [HttpGet("getallresponses")]
        public async Task<ActionResult<List<CarResponseDto>>> GetAllCarResponseAsync()
        {
            try
            {
                var getCarResponseQuery = new GetCarResponseQuery();
                var queryResponse = await _mediator.Send(getCarResponseQuery);
                _logger.LogInformation(LogEvents.GetAllCarResponses, "Fetched all Car responses");
                return Ok(queryResponse);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.CarResponseInternalError, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Post specific request to fake car service
        /// </summary>
        /// <param name="ToPublish"></param>
        /// <param name="carRequestDto"></param>
        /// <returns></returns>s

        [HttpPost("postrequesttocarservice/{ToPublish:bool}")]
        public async Task<ActionResult<CarResponseDto>> CreateAsyncToCarService(bool ToPublish, [FromBody] CarRequestDto carRequestDto)
        {
            try
            {
                var postToCarServiceCommand = new PostToCarServiceCommand(carRequestDto);
                var carResponse = await _mediator.Send(postToCarServiceCommand);
                if (ToPublish == true)
                {
                    var sendMessageCommand = new SendMessageCommand(carResponse);
                    await _mediator.Send(sendMessageCommand);
                }
                var checkCarResponseQuery = new CheckCarResponseQuery(carResponse.Brand, carResponse.Model);
                var checkResponse = await _mediator.Send(checkCarResponseQuery);
                if (checkResponse == true)
                {
                    var updateCarResponseCommand = new UpdateCarResponseCommand(carResponse);
                    var res = await _mediator.Send(updateCarResponseCommand);
                    _logger.LogInformation(LogEvents.UpdateCarResponseUpdated, "Updated an Car with car id: {CarId}", res.Id);
                    return res;

                }
                else
                {
                    var createCarResponseCommand = new CreateCarResponseCommand(carResponse);
                    var res = await _mediator.Send(createCarResponseCommand);
                    _logger.LogInformation(LogEvents.CreateCarResponseCreated, "Created an Car with car id: {CarId}", res.Id);
                    return res;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.CarResponseInternalError, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
