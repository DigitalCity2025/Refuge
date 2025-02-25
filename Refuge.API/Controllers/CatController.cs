using Microsoft.AspNetCore.Mvc;
using Refuge.API.DTO;
using Refuge.Application.Abstractions.Services;
using Refuge.Application.Entities;
using Refuge.Application.Enums;
using Refuge.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Refuge.API.Controllers
{
    [ApiController]
    [Route("Cat")]
    public class CatController(ICatService catService): ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]char letter, [FromQuery]CatColor color)
        {
            return Ok(catService.SearchByLetterAndColor(letter, color));
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id) 
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody]CatFormDTO dto)
        {
            catService.Add(
                new Cat { Name = dto.Name, Color = dto.Color }
            );
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Put(
            [FromRoute] int id, 
            [FromBody][MaxLength(25)] string nom
        )
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok();
        }
    }
}
