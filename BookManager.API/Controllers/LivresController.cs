using BookManager.API.Mappers;
using BookManager.API.Models.DTO;
using BookManager.BLL.Interfaces;
using BookManager.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivresController : ControllerBase
    {
        private ILivreService _livreService;
        private static int _currentUserId = 1;

        public LivresController(ILivreService livreService)
        {
            _livreService = livreService;
        }

        // GET: api/<LivreController>
        [HttpGet]
        [ProducesResponseType<List<LivreDTO>>(200)]
        [ProducesResponseType(204)]
        public IActionResult Get()
        {
            IEnumerable<LivreDTO> livres = _livreService.GetAll().Select(bll => bll.ToDTO());
            if (livres is null || livres.Count() == 0)
            {
                return NoContent();
            }
            return Ok(livres);
        }

        // GET api/<LivreController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType<LivreDTO>(200)]
        public IActionResult Get(int id)
        {
            LivreDTO livre;
            try
            {
                livre = _livreService.GetById(id).ToDTO();
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok(livre);
        }

        // POST api/<LivreController>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public IActionResult Post([FromBody] CreateLivreDTO newLivre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _livreService.Insert(newLivre.ToBLL());
            return CreatedAtAction(nameof(Get), null, null);
        }

        // PUT api/<LivreController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(201)]
        public IActionResult Put(int id, [FromBody] EditLivreDTO newLivre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _livreService.Update(id, newLivre.ToBLL());
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        // DELETE api/<LivreController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public IActionResult Delete(int id)
        {
            try
            {
                _livreService.Delete(id);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
