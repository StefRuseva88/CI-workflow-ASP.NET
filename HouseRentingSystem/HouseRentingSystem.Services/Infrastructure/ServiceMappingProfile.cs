using AutoMapper;
using HouseRentingSystem.Services.Agents.Models;
using HouseRentingSystem.Services.Data.Entities;
using HouseRentingSystem.Services.Houses.Models;
using HouseRentingSystem.Services.Rents.Models;
using HouseRentingSystem.Services.Users.Models;

namespace HouseRentingSystem.Services.Infrastructure
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<House, HouseIndexServiceModel>();

            this.CreateMap<House, HouseServiceModel>()
                .ForMember(h => h.IsRented, cfg => cfg.MapFrom(h => h.RenterId != null));

            this.CreateMap<House, HouseDetailsServiceModel>()
                .ForMember(h => h.IsRented, cfg => cfg.MapFrom(h => h.RenterId != null))
                .ForMember(h => h.Category, cfg => cfg.MapFrom(h => h.Category.Name));

            this.CreateMap<Agent, AgentServiceModel>()
                .ForMember(ag => ag.Email, cfg => cfg
                    .MapFrom(ag => ag.User.Email));

            this.CreateMap<Category, HouseCategoryServiceModel>();

            this.CreateMap<Agent, UserServiceModel>()
               .ForMember(us => us.Email, cfg => cfg.MapFrom(ag => ag.User.Email))
               .ForMember(us => us.FullName, cfg => cfg
                    .MapFrom(ag => ag.User.FirstName + " " + ag.User.LastName));

            this.CreateMap<User, UserServiceModel>()
              .ForMember(us => us.PhoneNumber, cfg => cfg.MapFrom(us => string.Empty))
              .ForMember(us => us.FullName, cfg => cfg
                    .MapFrom(us => us.FirstName + " " + us.LastName));

            this.CreateMap<House, RentServiceModel>()
             .ForMember(h => h.HouseTitle, cfg => cfg.MapFrom(h => h.Title))
             .ForMember(h => h.HouseImageURL, cfg => cfg.MapFrom(h => h.ImageUrl))
             .ForMember(h => h.AgentFullName, cfg => cfg
                  .MapFrom(h => h.Agent.User.FirstName + " " + h.Agent.User.LastName))
             .ForMember(h => h.AgentEmail, cfg => cfg.MapFrom(h => h.Agent.User.Email))
             .ForMember(h => h.RenterFullName, cfg => cfg
                  .MapFrom(h => h.Renter.FirstName + " " + h.Renter.LastName))
             .ForMember(h => h.RenterEmail, cfg => cfg.MapFrom(h => h.Renter.Email));
        }
    }
}


