using HouseRentingSystem.Services.Rents.Models;

namespace HouseRentingSystem.Services.Rents
{
    public interface IRentService
    {
        IEnumerable<RentServiceModel> All();
    }
}
