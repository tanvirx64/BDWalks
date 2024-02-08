using BDWalks.API.Models.Domain;

namespace BDWalks.API.Repositories
{
    public class InMemorryRegionRepository : IRegionRepository
    {
        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>() {
                new()
                {
                    Id = Guid.NewGuid(),
                    Code = "JPT",
                    Name = "Joypurhat Region",
                    RegionImageUrl = "joupurhat.jpg"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Code = "BGH",
                    Name = "Bagha Region",
                    RegionImageUrl = "bagha.jpg"
                }
            };
        }
    }
}
