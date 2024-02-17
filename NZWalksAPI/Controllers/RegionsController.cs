using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domains;
using NZWalksAPI.Models.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Repositories;
using AutoMapper;

namespace NZWalksAPI.Controllers
{
    // https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        // GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            // Get Data From Database - Domain models
            var regionsDomainModels = await regionRepository.GetAllAsync();

            // Map Domain Models to DTOs
            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomainModels);

            // Return DTOs to Client
            return Ok(regionsDto);
        }

        // GET SINGLE REGION (Get Refion By ID)
        // GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            // Get Region Domain Model From Database
            var regionDomainModel = await regionRepository.GetByIdAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            // Map the Region Domain Model to Region DTO (A single Region)
            // Return DTO to Client
            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

        // POST to Create New Region
        // POST: https://localhost:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionsRequestDto addRegionsRequestDto)
        {
            // Map ot Convert the DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionsRequestDto);
            
            // Use Domain Model to Create a Region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            // Map Domain Model back to DTO 
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
        }

        // Update region
        // PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto )
        {
            // Map DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);              
            
            if (regionDomainModel == null)
            {
                return NotFound();
            };

            // Convert Domain Model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);
            
           return Ok(regionDto);
        }


        // Delete region
        // DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            };

            // return the deleted region back
            //map domain model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }

    }
}
