using BDWalks.API.Models.Domain;

namespace BDWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
    }
}
