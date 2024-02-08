using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDWalks.API.Controllers
{
    // https://localhost:7104/Students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET:https://localhost:7104/Students
        [HttpGet]
        public IActionResult GetAll()
        {
            string[] students = new string[] { 
            "Tanvir", "Tarif", "Tamjid"
            };
            return Ok(students);
        }
    }
}
