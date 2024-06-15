using HouseRentingSystem.Services.Agents;

namespace HouseRentingSystem.Tests.UnitTests
{
    [TestFixture]
    public class AgentServiceTests : UnitTestsBase
    {
        private IAgentService agentService;

        [OneTimeSetUp]
        public void SetUp()
            => this.agentService = new AgentService(this.data);

        [Test]
        public void GetAgentId_ShouldReturnCorrectUserId()
        {
            // Arrange

            // Act: invoke the service method with valid id
            var resultAgentId = this.agentService.GetAgentId(this.Agent.UserId);

            // Assert a correct id is returned
            Assert.AreEqual(this.Agent.Id, resultAgentId);
        }

       [Test]
        public void ExistsById_ShouldReturnTrue_WithValidId()
        {
            // Arrange

            // Act: invoke the service method with valid agent id
            var result = this.agentService.ExistsById(this.Agent.UserId);

            // Assert the method result is true
            Assert.IsTrue(result);
        }

       
        [Test]
        public void AgentWithPhoneNumberExists_ShouldReturnTrue_WithValidData()
        {
            // Arrange

            // Act: invoke the service method with valid agent phone num
            var result = this.agentService
                .AgentWithPhoneNumberExists(this.Agent.PhoneNumber);

            // Assert the method result is true
            Assert.IsTrue(result);
        }

        
        [Test]
        public void CreateAgent_ShouldWorkCorrectly()
        {
            // Arrange: get all agents' current count
            var agentsCountBefore = this.data.Agents.Count();

            // Act: invoke the service method with valid data
            this.agentService.Create(this.Agent.UserId, this.Agent.PhoneNumber);

            // Assert the agents' count has increased by 1
            var agentsCountAfter = this.data.Agents.Count();
            Assert.AreEqual(agentsCountBefore + 1, agentsCountAfter);

            // Assert a new agent was created in the db with correct data
            var newAgentId = this.agentService.GetAgentId(this.Agent.UserId);
            var newAgentInDb = this.data.Agents.Find(newAgentId);
            Assert.IsNotNull(newAgentInDb);
            Assert.AreEqual(this.Agent.UserId, newAgentInDb.UserId);
            Assert.AreEqual(this.Agent.PhoneNumber, newAgentInDb.PhoneNumber);
        }
    }
}
