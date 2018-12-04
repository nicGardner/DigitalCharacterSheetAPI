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
    public class AttributesController : ControllerBase
    {
        private readonly DBConnect _context;

        public AttributesController(DBConnect context)
        {
            _context = context;
        }

        // GET: api/Attributes
        [HttpGet]
        public IEnumerable<AttributeModel> GetAttributes()
        {
            return _context.Attributes;
        }

        // GET: api/Attributes/5
        // return all attributes of a given character
        [HttpGet("{id}, {id2}")]
        public async Task<IActionResult> GetAttributeModel([FromRoute] string id, [FromRoute] string id2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attributeModel = await _context.Attributes.FindAsync(id, id2);

            if (attributeModel == null)
            {
                return NotFound();
            }

            return Ok(attributeModel);
        }

        // PUT: api/Attributes/5
        [HttpPut("{id}, {id2}")]
        public async Task<IActionResult> PutAttributeModel([FromRoute] string id, [FromRoute] string id2, [FromBody] AttributeModel attributeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attributeModel.characterName)
            {
                return BadRequest();
            }

            if (id2 != attributeModel.attributeName)
            {
                return BadRequest();
            }

            _context.Entry(attributeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeModelExists(id))
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

        // POST: api/Attributes
        [HttpPost]
        public async Task<IActionResult> PostAttributeModel([FromBody] AttributeModel attributeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Attributes.Add(attributeModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AttributeModelExists(attributeModel.characterName))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAttributeModel", new { id = attributeModel.characterName }, attributeModel);
        }

        // DELETE: api/Attributes/5
        [HttpDelete("{id}, {id2}")]
        public async Task<IActionResult> DeleteAttributeModel([FromRoute] string id, [FromRoute] string id2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attributeModel = await _context.Attributes.FindAsync(id, id2);
            if (attributeModel == null)
            {
                return NotFound();
            }

            _context.Attributes.Remove(attributeModel);
            await _context.SaveChangesAsync();

            return Ok(attributeModel);
        }

        private bool AttributeModelExists(string id)
        {
            return _context.Attributes.Any(e => e.characterName == id);
        }
    }
}