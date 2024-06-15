using HouseRentingSystem.Services.Users.Models;

namespace HouseRentingSystem.Services.Users
{
    public interface IUserService
    {
        bool UserHasRents(string userId);
        string UserFullName(string userId);
        IEnumerable<UserServiceModel> All();
    }
}
