using HouseRentingSystem.Services.Statistics.Models;
using HouseRentingSystem.Services.Statistics;

namespace HouseRentingSystem.Tests.UnitTests
{
    [TestFixture]
    public class StatisticsServiceTests : UnitTestsBase
    {
        private IStatisticsService statisticsService;

        [OneTimeSetUp]
        public void SetUp()
            => this.statisticsService = new StatisticsService(this.data);

        [Test]
        public void Total_ShouldReturnCorrectCounts()
        {
            // Arrange

            // Act: invoke the service method
            var result = this.statisticsService.Total();

            // Assert the returned result is not null
            Assert.IsNotNull(result);

            // Assert the returned houses' count is correct
            var housesCount = this.data.Houses.Count();
            Assert.AreEqual(housesCount, result.TotalHouses);

            // Assert the returned rents' count is correct
            var rentsCount = this.data.Houses.Where(h => h.RenterId != null).Count();
            Assert.AreEqual(rentsCount, result.TotalRents);
        }
    }
}
