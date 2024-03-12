using AutoMapper;
using BDWalks.API.CustomActionFilters;
using BDWalks.API.Data;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTO;
using BDWalks.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDWalks.API.Controllers
{
    // https://localhost:port/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper) {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        //GET ALL REGIONS
        //GET : https://localhost:port/api/regions
        [HttpGet]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from DB as Domain Model
            var regions = await regionRepository.GetAllAsync();

            //Map Domain Model to DTO
            var regionDtoList = mapper.Map<List<RegionDto>>(regions);

            //Return The DTO to the Client
            return Ok(regionDtoList);
        }

        //GET REGION BY ID
        //GET: https://localhost:port/api/regions/{id}
        [HttpGet]
        [Authorize(Roles = "Reader")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null) return NotFound();

            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }

        //POST TO ADD NEW REGION
        //POST: https://localhost:port/api/regions
        [HttpPost]
        [Authorize(Roles = "Writer")]
        [ValidateModal]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map DTO to Domain Model
            var regionDomain = mapper.Map<Region>(addRegionRequestDto);

            // Create and save Region in DB
            await regionRepository.CreateAsync(regionDomain);

            //Map Domain model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        //UPDATE REGION
        //PUT: https://localhost:port/api/regions/{id}
        [HttpPut]
        [Authorize(Roles = "Writer")]
        [Route("{id:Guid}")]
        [ValidateModal]
        public async Task<IActionResult> Update([FromRoute] Guid id ,[FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Map DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }

        //DELETE REGION
        //DELETE: https://localhost:port/api/regions/{id}
        [HttpDelete]
        [Authorize(Roles = "Writer")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
       
            if (regionDomainModel == null) return NotFound();

            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }
    }
}
