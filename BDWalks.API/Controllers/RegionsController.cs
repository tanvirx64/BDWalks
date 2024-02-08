using BDWalks.API.Data;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTO;
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
            //Get Data from DB as Domain Model
            var regions = _db.Regions.ToList();

            //Map Domain Model to DTO
            var regionDtoList = new List<RegionDto>();
            foreach (var regionDomain in regions) { 
                regionDtoList.Add(new RegionDto
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl,
                });
            }

            //Return The DTO to the Client
            return Ok(regionDtoList);
        }

        //GET REGION BY ID
        //GET: https://localhost:port/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var regionDomain = _db.Regions.Find(id);

            if (regionDomain == null) return NotFound();

            var regionDto = new RegionDto {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };
            
            return Ok(regionDto);
        }


        //POST TO ADD NEW REGION
        //POST: https://localhost:port/api/regions
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map DTO to Domain Model
            var regionDomain = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            };

            // Create and save Region in DB
            _db.Regions.Add(regionDomain);
            _db.SaveChanges();

            //Map Domain model to DTO
            var regionDto = new RegionDto
            {
                Id= regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id}, regionDto);
        }
    }
}
