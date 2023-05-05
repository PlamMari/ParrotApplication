using System;
using System.ComponentModel.DataAnnotations;

namespace BeersApplication.Models
{
    public class ParrotRequestDto
    {        
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
        [MaxLength(25, ErrorMessage = "The {0} field must be less than {1} characters.")]
        [MinLength(1, ErrorMessage = "The {0} field must be at least {1} character.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required and must not be an empty string.")]
        [MaxLength(25, ErrorMessage = "The {0} field must be less than {1} characters.")]
        [MinLength(1, ErrorMessage = "The {0} field must be at least {1} character.")]
        public string Size { get; set; }
        
        [Required]
        [Range(0.1, 5.0, ErrorMessage = "The {0} field must be between {1} and {2}.")]
        public double NoiseLevel { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The {0} field must be in the range from {1} to {2}.")]
        public int SpeciesId { get; set; }
    }
}
