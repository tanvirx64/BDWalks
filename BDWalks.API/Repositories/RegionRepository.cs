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
        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _db.Regions.FindAsync(id);
        }
        public async Task<Region> CreateAsync(Region region)
        {
            await _db.AddAsync(region);
            await _db.SaveChangesAsync();
            return region;
        }
        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await _db.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRegion == null) return null;

            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;
            
            await _db.SaveChangesAsync();

            return existingRegion;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var existingRegion = await _db.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRegion == null) return null;

            _db.Regions.Remove(existingRegion);
            await _db.SaveChangesAsync();

            return existingRegion;
        }
    }
}
