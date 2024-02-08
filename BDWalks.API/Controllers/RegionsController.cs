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
        //GET ALL REGIONS
        //GET : https://localhost:port/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = new List<Region>() { 
                new() {
                    Id = Guid.NewGuid(),
                    Code = "JSR",
                    Name = "Jassor",
                    RegionImageUrl = "https://www.shutterstock.com/shutterstock/photos/2302427907/display_1500/stock-photo-dhaka-bangladesh-daily-lifestyle-photos-of-village-people-in-bangladesh-village-life-2302427907.jpg"
                },
                new() {
                    Id = Guid.NewGuid(),
                    Code = "DHK",
                    Name = "Dhaka",
                    RegionImageUrl = "https://www.shutterstock.com/shutterstock/photos/2302427907/display_1500/stock-photo-dhaka-bangladesh-daily-lifestyle-photos-of-village-people-in-bangladesh-village-life-2302427907.jpg"
                },
                new() {
                    Id = Guid.NewGuid(),
                    Code = "BRL",
                    Name = "Barishal",
                    RegionImageUrl = "https://www.shutterstock.com/shutterstock/photos/2302427907/display_1500/stock-photo-dhaka-bangladesh-daily-lifestyle-photos-of-village-people-in-bangladesh-village-life-2302427907.jpg"
                },
            };

            return Ok(result);
        }
    }
}
