
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



        public DbSet<CharacterModel> Characters { get; set; }
        public DbSet<AttributeModel> Attributes { get; set; }

        // using fluent api to create a composite primary key for Attribute
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttributeModel>()
                .HasKey(a => new { a.characterName, a.attributeName });
        }
    }

}