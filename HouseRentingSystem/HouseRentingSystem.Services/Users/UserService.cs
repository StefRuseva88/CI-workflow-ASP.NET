using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseRentingSystem.Services.Data;
using HouseRentingSystem.Services.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Users
{
    public class UserService : IUserService
    {
        public bool UserHasRents(string userId)
            => this.data.Houses.Any(h => h.RenterId == userId);


        private readonly HouseRentingDbContext data;
        private readonly IMapper mapper;
        public UserService(HouseRentingDbContext data,
            IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }


        public string UserFullName(string userId)
        {
            var user = this.data.Users.Find(userId);

            if (string.IsNullOrEmpty(user.FirstName) 
                || string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return user.FirstName + " " + user.LastName;
        }

        public IEnumerable<UserServiceModel> All()
        {
            var allUsers = new List<UserServiceModel>();

            var agents = this.data
                .Agents
                .Include(ag => ag.User)
                .ProjectTo<UserServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            allUsers.AddRange(agents);

            var users = this.data
                .Users
                .Where(u => !this.data.Agents.Any(ag => ag.UserId == u.Id))
                .ProjectTo<UserServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            allUsers.AddRange(users);

            return allUsers;
        }
    }
}



