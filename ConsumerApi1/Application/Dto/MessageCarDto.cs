﻿using System.ComponentModel.DataAnnotations;

namespace ConsumerApi1.Application.Dto
{
    public class MessageCarDto
    {
        /// <summary>
        /// Car Id
        /// </summary>
        public Guid Id { get; set; }

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
        public List<MessageCarEngineDto> Engines { get; set; }
    }
}
