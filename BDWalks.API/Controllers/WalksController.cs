using AutoMapper;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTO;
using BDWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDWalks.API.Controllers
{
    // https://localhost:port/api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        //GET All Walks
        //GET: https://localhost:port/api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var walks = await walkRepository.GetAllAsync();
            return Ok(mapper.Map<List<WalkDto>>(walks));
        }

        //GET Walk By Id
        //GET: https://localhost:port/api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var walk = await walkRepository.GetByIdAsync(id);

            if (walk == null) return NotFound();

            return Ok(mapper.Map<WalkDto>(walk));
        }

        //CREATE Walks
        // POST: https://localhost:port/api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalksRequestDto)
        {
            //Map Dto to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalksRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }


        //Update Walks
        // PUT: https://localhost:port/api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            //Map Dto to Domain Model
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel = await walkRepository.UpdateAsync(walkDomainModel, id);

            if (walkDomainModel == null) return NotFound();

            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }

        //Delete Walks
        // DELETE: https://localhost:port/api/walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalk = await walkRepository.DeleteAsync(id);

            if (deletedWalk == null) return NotFound();    

            return Ok(mapper.Map<WalkDto>(deletedWalk));
        }

    }
}
