using AutoMapper;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Controllers;
using NZWalksAPI.Models.Domains;

namespace NZWalksAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionsRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();
          
        }
    }
}
