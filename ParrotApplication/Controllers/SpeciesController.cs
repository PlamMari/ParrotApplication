using BeersApplication.Exceptions;
using BeersApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeersApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesService speciesService;
        public SpeciesController(ISpeciesService speciesService)
        {
            this.speciesService = speciesService;
        }

        [HttpGet("")]
        public IActionResult Get() {
            var species = this.speciesService.Get();
            return StatusCode(StatusCodes.Status200OK, species);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try
            {
                var species = this.speciesService.Get(id);
                return this.StatusCode(StatusCodes.Status200OK, species);
            }
            catch(EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        
        }
    }
}
