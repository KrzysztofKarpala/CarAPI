using CarFakeService.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CarFakeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarServiceController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CarResponseDto>> CarPost([FromBody] CarRequestDto carRequest)
        {
            try
            {
                var response = new CarResponseDto
                {
                    Brand = carRequest.Brand,
                    Model = carRequest.Model,
                    Engines = new()
                    {
                        new CarResponseEngineDto{Capacity = 1000, Hp = 80, Fuel = "Gasoline"},
                        new CarResponseEngineDto{Capacity = 1800, Hp = 120, Fuel = "Diesel"},
                        new CarResponseEngineDto{Capacity = 2500, Hp = 1500, Fuel = "Gasoline+LPG"},
                    }
                };
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
