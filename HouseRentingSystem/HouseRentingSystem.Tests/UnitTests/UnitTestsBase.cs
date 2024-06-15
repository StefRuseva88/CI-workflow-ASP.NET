using HouseRentingSystem.Services.Data;
using HouseRentingSystem.Tests.Mocks;

using AutoMapper;
using NUnit.Framework;

using HouseRentingSystem.Services.Data.Entities;

namespace HouseRentingSystem.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected HouseRentingDbContext data;
        protected IMapper mapper;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            this.data = DatabaseMock.Instance;
            this.mapper = MapperMock.Instance;
            this.SeedDatabase();
        }
        public User Renter { get; private set; }
        public Agent Agent { get; private set; }
        public House RentedHouse { get; private set; }

        private void SeedDatabase()
        {
            this.Renter = new User()
            {
                Id = "RenterUserId",
                Email = "rent@er.bg",
                FirstName = "Renter",
                LastName = "User"
            };
            this.data.Users.Add(this.Renter);

            this.Agent = new Agent()
            {
                PhoneNumber = "+359111111111",
                User = new User()
                {
                    Id = "TestUserId",
                    Email = "test@test.bg",
                    FirstName = "Test",
                    LastName = "Tester"
                }
            };
            this.data.Agents.Add(this.Agent);

            this.RentedHouse = new House()
            {
                Title = "First Test House",
                Address = "Test, 201 Test",
                Description = "This is a test description. This is a test description. This is a test description.",
                ImageUrl = "https://www.bhg.com/thmb/0Fg0imFSA6HVZMS2DFWPvjbYDoQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9.jpg",
                Renter = this.Renter,
                Agent = this.Agent,
                Category = new Category() { Name = "Cottage" }
            };
            this.data.Houses.Add(this.RentedHouse);

            var nonRentedHouse = new House()
            {
                Title = "Second Test House",
                Address = "Test, 204 Test",
                Description = "This is another test description. This is another test description.",
                ImageUrl = "https://images.adsttc.com/media/images/629f/3517/c372/5201/650f/1c7f/large_jpg/hyde-park-house-robeson-architects_1.jpg?1654601149",
                Renter = this.Renter,
                Agent = this.Agent,
                Category = new Category() { Name = "Single-Family" }
            };

            this.data.Houses.Add(nonRentedHouse);
            this.data.SaveChanges();

        }

        [OneTimeTearDown]
        public void TearDownBase()
           => this.data.Dispose();
    }
}
