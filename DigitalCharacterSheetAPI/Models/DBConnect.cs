
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DigitalCharacterSheetAPI.Models

{

    public class DBConnect : DbContext

    {

        public DBConnect(DbContextOptions<DBConnect> options) : base(options)
        {

        }



        public DbSet<Character> Characters { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
    }

}