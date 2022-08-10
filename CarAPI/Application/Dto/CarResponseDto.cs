using System.ComponentModel.DataAnnotations;

namespace CarAPI.Application.Dto
{
    public class CarResponseDto
    {
        /// <summary>
        /// Car Id
        /// </summary>
        [Key]
        [Required]
        [Range(1, int.MaxValue)]
        public int CarId { get; set; }

        /// <summary>
        /// Car Brand
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Brand { get; set; }

        /// <summary>
        /// Car Model
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Model { get; set; }

        /// <summary>
        /// Engine lists
        /// </summary>
        public List<CarResponseEngineDto> Engines { get; set; }
    }
}
