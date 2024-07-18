

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using modelopi.Entites;

namespace modelopi.Context

{
    public class AgendaDbContext : DbContext
    {
        public AgendaDbContext(DbContextOptions<AgendaDbContext> options) : base(options)
        { }
        public DbSet<Contato> Contatos { get; set; }

       
    }
}
