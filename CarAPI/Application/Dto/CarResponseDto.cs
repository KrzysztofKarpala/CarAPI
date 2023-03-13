using System.ComponentModel.DataAnnotations;

namespace CarAPI.Application.Dto
{
    public class CarResponseDto
    {
        /// <summary>
        /// Car Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Car Brand
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Car Model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Engine lists
        /// </summary>
        public List<CarResponseEngineDto> Engines { get; set; }
    }
}
