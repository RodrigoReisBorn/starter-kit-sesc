using Microsoft.EntityFrameworkCore;
using Stefanini.DemoApp.Domain.Entities;
using Stefanini.DemoApp.Infrastructure.Data.Mappings;

namespace Stefanini.DemoApp.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { } 

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Aluno>(new AlunoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
