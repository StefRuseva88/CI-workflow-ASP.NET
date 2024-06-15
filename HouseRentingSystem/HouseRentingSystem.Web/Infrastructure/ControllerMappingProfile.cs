using AutoMapper;
using HouseRentingSystem.Services.Houses.Models;
using HouseRentingSystem.Web.Models.Houses;

namespace HouseRentingSystem.Web.Infrastructure
{
    public class ControllerMappingProfile
        : Profile
    {
        public ControllerMappingProfile()
        {
            this.CreateMap<HouseDetailsServiceModel, HouseFormModel>();
            this.CreateMap<HouseDetailsServiceModel, HouseDetailsViewModel>();
        }
    }
}
