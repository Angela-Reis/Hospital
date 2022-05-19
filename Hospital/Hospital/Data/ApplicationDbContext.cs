using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;

namespace Hospital.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Consultas> Consultas { get; set; }
        public DbSet<Diagnosticos> Diagnosticos { get; set; }
        public DbSet<Especialidades> Especialidades { get; set; }
        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Pagamentos> Pagamentos { get; set; }
        public DbSet<Prescricoes> Prescricoes { get; set; }
        public DbSet<Utentes> Utentes { get; set; }



    }
}