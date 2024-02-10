using BDWalks.API.Models.Domain;

namespace BDWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id); 
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> UpdateAsync(Walk walk, Guid id);

    }
}
