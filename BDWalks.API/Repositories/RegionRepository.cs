using BDWalks.API.Data;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace BDWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly BDWalksDbContext _db;
        public RegionRepository(BDWalksDbContext db)
        {
            this._db = db;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await _db.Regions.ToListAsync();
        }
    }
}
