using AutoMapper;
using PowerPlants.Api.DTOs;
using PowerPlants.Business.Models;

namespace PowerPlants.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<PayLoad, PayLoadDTO>().ReverseMap();            
            CreateMap<Production, ProductionDTO>().ReverseMap();            
            CreateMap<Fuels, FuelsDTO>().ReverseMap();
            CreateMap<PowerPlant, PowerPlantDTO>().ReverseMap();
        }
    }
}