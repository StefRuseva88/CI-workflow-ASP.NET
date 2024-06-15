using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Services.Data.DataConstants.Category;

namespace HouseRentingSystem.Services.Data.Entities
{
    public class Category
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public IEnumerable<House> Houses { get; init; } = new List<House>();
    }
}
