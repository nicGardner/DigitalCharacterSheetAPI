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
    public class CharactersController : ControllerBase
    {
        // db connection
        private DBConnect db;

        public CharactersController(DBConnect db)
        {
            this.db = db;
        }

        // GET: api/characters
        [HttpGet]
        public IEnumerable<Character> Get()

        {
            return db.Characters.OrderBy(c => c.character_name).ToList();
        }

    }
}