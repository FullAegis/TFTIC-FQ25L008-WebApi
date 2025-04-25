using BookManager.API.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivresStaticController : ControllerBase
    {
        private static List<LivreDTO> _livres;
        private static int _currentUserId = 1;

        public LivresStaticController()
        {
            _livres ??= new List<LivreDTO>();
        }

        // GET: api/<LivreController>
        [HttpGet]
        [ProducesResponseType<List<LivreDTO>>(200)]
        [ProducesResponseType(204)]
        public IActionResult Get()
        {
            if(_livres is null || _livres.Count == 0)
            {
                return NoContent();
            }
            return Ok(_livres);
        }

        // GET api/<LivreController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType<LivreDTO>(200)]
        public IActionResult Get(int id)
        {
            LivreDTO? livre = _livres.SingleOrDefault(l => l.Id == id);
            if(livre is null)
            {
                return NotFound();
            }
            return Ok(livre);
        }

        // POST api/<LivreController>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType<LivreDTO>(201)]
        public IActionResult Post([FromBody]CreateLivreDTO newLivre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LivreDTO livre = new LivreDTO()
            {
                Id = ((_livres.Count > 0)?_livres.Max(l => l.Id) : 0) + 1,
                Titre = newLivre.Titre,
                Auteur = newLivre.Auteur,
                Annee = newLivre.Annee,
                NbrePage = newLivre.NbrePage,
                UtilisateurId = _currentUserId
            };
            _livres.Add(livre);
            return CreatedAtAction(nameof(Get), new { id = livre.Id }, livre);
        }

        // PUT api/<LivreController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType<LivreDTO>(201)]
        public IActionResult Put(int id, [FromBody]EditLivreDTO newLivre)
        {
            LivreDTO? livre = _livres.SingleOrDefault(l => l.Id == id);
            if (livre is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            livre.Titre = newLivre.Titre;
            livre.Auteur = newLivre.Auteur;
            livre.Annee = newLivre.Annee;
            livre.NbrePage = newLivre.NbrePage;
            return CreatedAtAction(nameof(Get), new { id = livre.Id }, livre);
        }

        // DELETE api/<LivreController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public IActionResult Delete(int id)
        {
            LivreDTO? livre = _livres.SingleOrDefault(l => l.Id == id);
            if (livre is null)
            {
                return NotFound();
            }
            _livres.Remove(livre);
            return NoContent();
        }
    }
}
