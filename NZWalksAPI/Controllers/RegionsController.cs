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
    }
}
