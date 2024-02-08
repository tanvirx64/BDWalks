using BDWalks.API.Data;
using BDWalks.API.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDWalks.API.Controllers
{
    // https://localhost:port/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly BDWalksDbContext _db;
        public RegionsController(BDWalksDbContext db) {
            this._db = db;
        }
        //GET ALL REGIONS
        //GET : https://localhost:port/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _db.Regions.ToList();
            return Ok(regions);
        }

        //GET REGION BY ID
        //GET: https://localhost:port/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = _db.Regions.Find(id);

            if (region == null) return NotFound();
            
            return Ok(region);
        }


    }
}
