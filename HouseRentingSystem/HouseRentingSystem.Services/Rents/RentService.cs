using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseRentingSystem.Services.Data;
using HouseRentingSystem.Services.Rents.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services.Rents
{
    public class RentService : IRentService
    {
        private readonly HouseRentingDbContext data;
        private readonly IMapper mapper;

        public RentService(HouseRentingDbContext data,
            IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public IEnumerable<RentServiceModel> All()
        {
            return this.data
                .Houses
                .Include(h => h.Agent.User)
                .Include(h => h.Renter)
                .Where(h => h.RenterId != null)
                .ProjectTo<RentServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
