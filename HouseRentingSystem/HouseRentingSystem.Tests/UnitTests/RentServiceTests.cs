using HouseRentingSystem.Services.Rents;

namespace HouseRentingSystem.Tests.UnitTests
{
    [TestFixture]
    public class RentServiceTests : UnitTestsBase
    {
        private IRentService rentService;

        [OneTimeSetUp]
        public void SetUp()
            => this.rentService = new RentService(this.data, this.mapper);

        [Test]
        public void All_ShouldReturnCorrectData()
        {
            // Arrange

            // Act: invoke the service method
            var result = this.rentService.All();

            // Assert the result is not null
            Assert.IsNotNull(result);

            // Assert the returned rents' count is correct
            var rentedHousesInDb = this.data.Houses
                .Where(h => h.RenterId != null);
            Assert.AreEqual(rentedHousesInDb.Count(), result.ToList().Count());

            // Assert a returned rent's data is correct
            var resultHouse = result.ToList()
                .Find(h => h.HouseTitle == this.RentedHouse.Title);
            Assert.IsNotNull(resultHouse);
            Assert.AreEqual(this.Renter.Email, resultHouse.RenterEmail);
            Assert.AreEqual(this.Renter.FirstName + " " + this.Renter.LastName,
                resultHouse.RenterFullName);
            Assert.AreEqual(this.Agent.User.Email, resultHouse.AgentEmail);
            Assert.AreEqual(this.Agent.User.FirstName + " " + this.Agent.User.LastName,
                resultHouse.AgentFullName);
        }
    }
}
