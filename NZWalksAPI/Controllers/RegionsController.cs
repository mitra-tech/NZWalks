using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domains;
using NZWalksAPI.Models.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    // https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }
        // GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            // Get Data From Database - Domain models
            var regionsDomainModels = await regionRepository.GetAllAsync();

            // Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var regionsDomainModel in regionsDomainModels)
            {
                regionsDto.Add(new RegionDto() 
                { 
                    Id = regionsDomainModel.Id,
                    Code = regionsDomainModel.Code,
                    Name = regionsDomainModel.Name,
                    RegionImageUrl = regionsDomainModel.RegionImageUrl,
                });
            }
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
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            // Map the Region Domain Model to Region DTO (A single Region)
            var regionDto = new RegionDto()
            { 
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            // Return DTO to Client
            return Ok(regionDto);
        }

        // POST to Create New Region
        // POST: https://localhost:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionsRequestDto addRegionsRequestDto)
        {
            // Map ot Convert the DTO to Domain Model
            var regionDomainModle = new Region
            {
                Code = addRegionsRequestDto.Code,
                Name = addRegionsRequestDto.Name,
                RegionImageUrl = addRegionsRequestDto.RegionImageUrl,
            };
            
            // Use Domain Model to Create a Region
            await dbContext.Regions.AddAsync(regionDomainModle);
            await dbContext.SaveChangesAsync();

            // Map Domain Model back to DTO 
            var regionDto = new RegionDto
            {
                Id = regionDomainModle.Id,
                Code = regionDomainModle.Code,
                Name = regionDomainModle.Name,
                RegionImageUrl = regionDomainModle.RegionImageUrl,
            };


            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
        }

        // Update region
        // PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto )
        {
            // Check if region exists
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            
            if (regionDomainModel == null)
            {
                return NotFound();
            };
            // Map Dto to Domain Model
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            // Convert Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };
            
           return Ok(regionDto);
        }


        // Delete region
        // DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Check if region exists
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            };

            // Delete region
            dbContext.Regions.Remove(regionDomainModel);
            await dbContext.SaveChangesAsync();

            // return the deleted region back
            //map domain model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return Ok(regionDto);
        }

    }
}
