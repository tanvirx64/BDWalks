using AutoMapper;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTO;

namespace BDWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region,RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto,Region>();
            CreateMap<UpdateRegionRequestDto,Region>();
        }
    }
}
