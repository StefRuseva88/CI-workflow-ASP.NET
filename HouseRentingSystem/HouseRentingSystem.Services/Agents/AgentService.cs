using HouseRentingSystem.Services.Data;
using HouseRentingSystem.Services.Data.Entities;

namespace HouseRentingSystem.Services.Agents
{
    public class AgentService : IAgentService 
    {
        private readonly HouseRentingDbContext data;

        public AgentService(HouseRentingDbContext data)
           => this.data = data;

        //public bool UserHasRents(string userId)
          //  => this.data.Houses.Any(h => h.RenterId == userId);

        public bool AgentWithPhoneNumberExists(string phoneNumber)
           => this.data.Agents.Any(a => a.PhoneNumber == phoneNumber);
        
        
        public int GetAgentId(string userId)
           => this.data.Agents
                   .FirstOrDefault(a => a.UserId == userId)
                   .Id;

        public bool ExistsById(string userId)
            => this.data.Agents.Any(a => a.UserId == userId);

       

        

        public void Create(string userId, string phoneNumber)
        {
            var agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            this.data.Agents.Add(agent);
            this.data.SaveChanges();
        }


    }
}
