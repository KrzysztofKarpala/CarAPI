using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarAPI.Application.Dto
{
    public class CarRequestDto
    {
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
    }
}
