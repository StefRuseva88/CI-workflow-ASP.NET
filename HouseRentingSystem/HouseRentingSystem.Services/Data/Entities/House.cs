using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static HouseRentingSystem.Services.Data.DataConstants.House;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Services.Data.Entities
{
    public class House
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Column(TypeName = "decimal(12,3)")]
        public decimal PricePerMonth { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

        public int AgentId { get; set; }

        public Agent Agent { get; init; }

        public string? RenterId { get; set; }
        public User Renter { get; init; }
    }
}
