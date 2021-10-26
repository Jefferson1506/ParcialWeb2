using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entidad;

namespace Datos
{
    public class ParcialWebContext : DbContext
    {
        public ParcialWebContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Persona> Personas{get;set;}
        
        public DbSet<Infraccion> Infracciones{get;set;}
    }
}