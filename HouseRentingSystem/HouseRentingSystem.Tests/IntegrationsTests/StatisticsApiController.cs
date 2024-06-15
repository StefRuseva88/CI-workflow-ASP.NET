using HouseRentingSystem.Tests.Mocks;
using HouseRentingSystem.Web.Controllers.Api;

namespace HouseRentingSystem.Tests.IntegrationsTests
{
    public class StatisticsApiControllerTests
    {
        private StatisticsApiController statisticsController;

        [OneTimeSetUp]
        public void SetUp()
            => this.statisticsController =
                new StatisticsApiController(StatisticsServiceMock.Instance);

        [Test]
        public void GetStatistics_ShouldReturnCorrectCounts()
        {
            // Arrange

            // Act: invoke the service method
            var result = this.statisticsController.GetStatistics();

            // Assert the returned result counts are correct
            Assert.NotNull(result);
            Assert.That(result.TotalHouses, Is.EqualTo(10));
            Assert.That(result.TotalRents, Is.EqualTo(6));
        }
    }
}
