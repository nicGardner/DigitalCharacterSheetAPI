using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalCharacterSheetAPI.Models;

namespace DigitalCharacterSheetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Characters1Controller : ControllerBase
    {
        private readonly DBConnect _context;

        public Characters1Controller(DBConnect context)
        {
            _context = context;
        }

        // GET: api/Characters1
        [HttpGet]
        public IEnumerable<Character> GetCharacters()
        {
            return _context.Characters;
        }

        // GET: api/Characters1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCharacter([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        // PUT: api/Characters1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter([FromRoute] string id, [FromBody] Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != character.character_name)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Characters1
        [HttpPost]
        public async Task<IActionResult> PostCharacter([FromBody] Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", new { id = character.character_name }, character);
        }

        // DELETE: api/Characters1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return Ok(character);
        }

        private bool CharacterExists(string id)
        {
            return _context.Characters.Any(e => e.character_name == id);
        }
    }
}