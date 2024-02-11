using BDWalks.API.Data;
using BDWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BDWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly BDWalksDbContext db;

        public WalkRepository(BDWalksDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null)
        {
            var walks = db.Walks.Include("Difficulty").Include("Region").AsQueryable();

            //Filter
            if (string.IsNullOrEmpty(filterOn) == false && string.IsNullOrEmpty(filterQuery) == false)
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }
            return await walks.ToListAsync();
            //return await db.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            var walk = await db.Walks
                      .Include("Difficulty")
                      .Include("Region")
                      .FirstOrDefaultAsync(w => w.Id == id);
            if(walk == null) return null;
            return walk;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await db.Walks.AddAsync(walk);
            await db.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> UpdateAsync(Walk walk, Guid id)
        {
            var existingWalk = await db.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(existingWalk == null) { return null; }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;

            await db.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await db.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(existingWalk == null) return null;

            db.Walks.Remove(existingWalk);
            await db.SaveChangesAsync();
            return existingWalk;
        }
    }
}
