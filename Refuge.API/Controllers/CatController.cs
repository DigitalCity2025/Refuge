using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Refuge.API.Controllers
{
    [ApiController]
    [Route("Cat")]
    public class CatController: ControllerBase
    {
        static List<string> dbChat 
            =  [ "Miaouss", "Felix", "Garfield", "Duchesse" ];

        [HttpGet]
        public IActionResult Get([FromQuery]char letter)
        {
            return Ok(dbChat.Where(c => c.Contains(letter)));
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id) 
        {
            try
            {
                return Ok(dbChat[id]);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post(
            [FromBody][MaxLength(25)]string nom
        )
        {
            if(dbChat.Contains(nom))
            {
                ModelState.AddModelError("nom", "the name must be unique");
                return BadRequest(ModelState);
            }
            dbChat.Add(nom);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Put(
            [FromRoute] int id, 
            [FromBody][MaxLength(25)] string nom
        )
        {
            try
            {
                dbChat[id] = nom;
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (dbChat[id] != null)
                {
                    dbChat.RemoveAt(id);
                }
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
