using BDWalks.API.Models.Domain;

namespace BDWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true);
        Task<Walk?> GetByIdAsync(Guid id); 
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> UpdateAsync(Walk walk, Guid id);
        Task<Walk?> DeleteAsync(Guid id);

    }
}
