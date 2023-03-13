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
        private readonly HttpClient _client;
        private readonly IMediator _mediator;

        public CarController(ILogger<CarController> logger, HttpClient client, IMediator mediator)
        {
            _logger = logger;
            _client = client;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all responses from database
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetAllResponses")]
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
                var message = "Failed to fetch Car responses";
                _logger.LogWarning(LogEvents.CarResponseInternalError, ex, message);
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
        }

        /// <summary>
        /// Post specific request to fake car service
        /// </summary>
        /// <param name="ToPublish"></param>
        /// <param name="newRequest"></param>
        /// <returns></returns>

        [HttpPost("PostRequestToFakeCarService/{ToPublish:bool}")]
        public async Task<ActionResult<CarResponseDto>> CreateAsyncToFakeCarService(bool ToPublish, [FromBody] CarRequestDto newRequest)
        {
            try
            {
                _client.BaseAddress = new Uri("http://host.docker.internal:8091/");
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                //var jsonRequest = JsonConvert.SerializeObject(newRequest);
                HttpResponseMessage NewResponse = await _client.PostAsJsonAsync("api/CarService", newRequest);
                
                if (NewResponse.IsSuccessStatusCode)
                {
                    var data = await NewResponse.Content.ReadAsStringAsync();
                    CarResponseDto? carResponse = JsonConvert.DeserializeObject<CarResponseDto>(data);
                    carResponse.Id = Guid.NewGuid();
                    if(carResponse is null)
                    {
                        _logger.LogWarning(LogEvents.CarResponseBadRequest, "Bad request, car fake service response statuscode is null");
                        return BadRequest();
                    }
                    if(ToPublish == true)
                    {
                        var sendMessageCommand = new SendMessageCommand { CarResponseDto = carResponse };
                        await _mediator.Send(sendMessageCommand);
                    }
                    var checkCarResponseQuery = new CheckCarResponseQuery { Brand = carResponse.Brand, Model = carResponse.Model };
                    var checkResponse = await _mediator.Send(checkCarResponseQuery);
                    if(checkResponse == true)
                    {
                        var updateCarResponseCommand = new UpdateCarResponseCommand { carResponseDto = carResponse };
                        await _mediator.Send(updateCarResponseCommand);
                        _logger.LogInformation(LogEvents.UpdateCarResponseUpdated, "Updated an Car with car id: {CarId}", carResponse.Id);
                        return Ok(updateCarResponseCommand.carResponseDto);

                    }
                    else
                    {
                        var createCarResponseCommand = new CreateCarResponseCommand { carResponseDto = carResponse };
                        await _mediator.Send(createCarResponseCommand);
                        _logger.LogInformation(LogEvents.CreateCarResponseCreated, "Created an Car with car id: {CarId}", carResponse.Id);
                        return Ok(createCarResponseCommand.carResponseDto);
                    }
                }
                _logger.LogWarning(LogEvents.CarResponseBadRequest, "BadRequest, fake car service response statuscode is {StatusCode}", NewResponse.StatusCode);
                return BadRequest();
            }
            catch (Exception ex)
            {
                var message = "Failed to fetch Car responses";
                _logger.LogWarning(LogEvents.CarResponseInternalError, ex, message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
