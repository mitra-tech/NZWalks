using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domains;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Controllers
{
    // https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll() 
        {
            // Get Data From Database - Domain models
            var regionsDomainModels = dbContext.Regions.ToList();

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
        public IActionResult GetById([FromRoute] Guid id) 
        {
            // Get Region Domain Model From Database
            var regionDomainModel = dbContext.Regions.FirstOrDefault(r => r.Id == id);

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
        public IActionResult Create([FromBody] AddRegionsRequestDto addRegionsRequestDto)
        {
            // Map ot Convert the DTO to Domain Model
            var regionDomainModle = new Region
            {
                Code = addRegionsRequestDto.Code,
                Name = addRegionsRequestDto.Name,
                RegionImageUrl = addRegionsRequestDto.RegionImageUrl,
            };
            
            // Use Domain Model to Create a Region
            dbContext.Regions.Add(regionDomainModle);
            dbContext.SaveChanges();

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
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto )
        {
            // Check if region exists
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            
            if (regionDomainModel == null)
            {
                return NotFound();
            };
            // Map Dto to Domain Model
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            dbContext.SaveChanges();

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

    }
}
