using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Refuge.API.Controllers
{
    [ApiController]
    [Route("Cat")]
    public class CatController: ControllerBase
    {
        static List<string> l 
            =  [ "Miaouss", "Felix", "Garfield", "Duchesse" ];

        [HttpGet]
        public IActionResult Get([FromQuery]char letter)
        {
            return Ok(l.Where(c => c.Contains(letter)));
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id) 
        {
            try
            {
                return Ok(l[id]);
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
            if(l.Contains(nom))
            {
                ModelState.AddModelError("nom", "the name must be unique");
                return BadRequest(ModelState);
            }
            l.Add(nom);
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
                l[id] = nom;
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
                if (l[id] != null)
                {
                    l.RemoveAt(id);
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
