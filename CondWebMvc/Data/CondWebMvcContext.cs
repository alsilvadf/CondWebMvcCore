using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CondWebMvc.Models
{
    public class CondWebMvcContext : DbContext
    {
        public CondWebMvcContext (DbContextOptions<CondWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<ControleVisitas> Visita { get; set; }
        public DbSet<ControleVisitas> ControleVisitas { get; set; }
        public DbSet<Morador> Morador { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
     
    }
}
