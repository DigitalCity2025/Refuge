using Refuge.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace Refuge.API.DTO
{
    public class CatFormDTO
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = null!;

        [Required]
        public CatColor Color { get; set; }
    }
}
