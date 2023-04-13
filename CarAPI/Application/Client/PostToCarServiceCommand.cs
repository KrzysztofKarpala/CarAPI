using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Core.Entities;
using CarAPI.Core.Repository;
using CarAPI.Utils;
using MediatR;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;

namespace CarAPI.Application.Client
{
    public record PostToCarServiceCommand(CarRequestDto carRequestDto) : IRequest<CarResponseDto>
    {
    }
    public class PostToCarServiceCommandHandler : IRequestHandler<PostToCarServiceCommand, CarResponseDto>
    {
        private readonly ILogger<PostToCarServiceCommandHandler> _logger;
        private readonly HttpClient _client;

        public PostToCarServiceCommandHandler(ILogger<PostToCarServiceCommandHandler> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<CarResponseDto> Handle(PostToCarServiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _client.BaseAddress = new Uri("http://host.docker.internal:8091/");
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                //var jsonRequest = JsonConvert.SerializeObject(newRequest);
                HttpResponseMessage NewResponse = await _client.PostAsJsonAsync("api/CarService", request.carRequestDto);
                if (!NewResponse.IsSuccessStatusCode)
                {
                    throw new BadRequstException();
                }
                var data = await NewResponse.Content.ReadAsStringAsync();
                CarResponseDto? carResponse = JsonConvert.DeserializeObject<CarResponseDto>(data);
                carResponse.Id = Guid.NewGuid();
                return carResponse;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.CreateCarResponseCommandHandlerFailure, ex, "CreateCarResponseCommandHandler failed");
                throw ex;
            }
        }
    }
}
