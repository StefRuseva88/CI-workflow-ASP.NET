namespace HouseRentingSystem.Services.Houses.Models
{
    public class HouseIndexServiceModel : IHouseModel
    {
        public string Address { get; init; }
        public int Id { get; init; }
        public string Title { get; init; }
        public string ImageUrl { get; init; }
    }
}
