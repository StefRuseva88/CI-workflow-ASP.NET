using HouseRentingSystem.Services.Data;
using HouseRentingSystem.Services.Statistics.Models;

namespace HouseRentingSystem.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly HouseRentingDbContext data;

        public StatisticsService(HouseRentingDbContext data)
            => this.data = data;

        public StatisticsServiceModel Total()
        {
            var totalHouses = this.data.Houses.Count();
            var totalRents = this.data.Houses
                .Where(h => h.RenterId != null).Count();

            return new StatisticsServiceModel
            {
                TotalHouses = totalHouses,
                TotalRents = totalRents
            };
        }
    }
}
