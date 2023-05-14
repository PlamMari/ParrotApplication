using ParrotsApplication.Exceptions;
using ParrotsApplication.Models;
using ParrotsApplication.Models.Mappers;
using ParrotsApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ParrotsApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParrotsController : ControllerBase
    {
        private readonly IParrotsService parrotsService;
        private readonly ParrotMapper mapper;

        public ParrotsController(IParrotsService parrotService, ParrotMapper mapper)
        {
            this.parrotsService = parrotService;
            this.mapper = mapper;
        }

        //get all parrots
        [HttpGet("")]
        public IActionResult GetAllParrots([FromQuery] ParrotQueryParameters filterParameters)
        {
            var parrots = this.parrotsService.Get(filterParameters)
                .Select(b => new ParrotResponseDto(b))
                .ToList();
            return this.StatusCode(StatusCodes.Status200OK, parrots);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var parrot = this.parrotsService.Get(id);

                return this.StatusCode(StatusCodes.Status200OK, this.mapper.ConvertToDto(parrot));
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpPost("")]
        public IActionResult Create([FromBody] ParrotRequestDto dto)
        {
            try
            {
                var parrot = this.mapper.ConvertToModel(dto);
                var createdParrot = this.parrotsService.Create(parrot);
                return this.StatusCode(StatusCodes.Status201Created, this.mapper.ConvertToDto(createdParrot));
            }
            catch (DuplicateEntityException e)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, /*[FromHeader] string authorization, */[FromBody] ParrotRequestDto dto)
        {
            try
            {
                //var user = this.authorizationHelper.TryGetUser(authorization);
                var parrot = this.mapper.ConvertToModel(dto);
                parrot.Id = id;
                var updatedParrot = this.parrotsService.Update(id, parrot);
                return this.StatusCode(StatusCodes.Status200OK, updatedParrot);
            }
            /*catch (UnauthorizedAccessException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }*/
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id/*, [FromHeader] string authorization*/)
        {
            try
            {
                //var user = this.authorizationHelper.TryGetUser(authorization);
                this.parrotsService.Delete(id /*, user */);
                return Ok();
            }
            /*catch (UnauthorizedAccessException e)
            {
                return this.StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }*/
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }
    }
}
