using Microsoft.EntityFrameworkCore;
using ModelMVC.Models;

namespace ModelMVC.Context
{
    public class AgendaContext : DbContext
    {

        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) { }

        public DbSet<Contato> Contatos{ get; set; }
    }
}
