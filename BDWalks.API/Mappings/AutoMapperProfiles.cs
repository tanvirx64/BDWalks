using AutoMapper;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTO;

namespace BDWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Region
            CreateMap<Region,RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto,Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto,Region>().ReverseMap();
            
            //Walk
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<AddWalksRequestDto, Walk>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
            
            //Difficulty
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}
