namespace CarFakeService.Application.Dto
{
    public class CarResponseDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<CarResponseEngineDto> Engines { get; set; }
    }
}
