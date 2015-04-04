using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CodeFirstEF6.Models;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace CodeFirstEF6.DAL
{
    public class CatalogoContext : DbContext
    {
        public CatalogoContext() : base("CatalogoContext")
        {
        }
        
        public DbSet<PeliculaViewModel> Peliculas { get; set; }
        public DbSet<GeneroViewModel> Generos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}