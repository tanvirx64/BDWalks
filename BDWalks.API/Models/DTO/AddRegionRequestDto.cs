using System.ComponentModel.DataAnnotations;

namespace BDWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name Must be Minimum 3 Characters")]
        [MaxLength(3, ErrorMessage = "Name Must be Maximum 3 Characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage = "Name Must be Maximum 100 Characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
