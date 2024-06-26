using Microsoft.EntityFrameworkCore;

namespace Gymapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opitions) : base(opitions)
        {

        }

        public DbSet<members> Tb_MEMBERS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Members>().ToTable("TB_MEMBERS");

            modelBuilder.Entity<Members>().HasData
            (
                new Members() { Id = 01, Nome = "Brad", Email = "brad@gmail.com", Nivelconta = 10, Classe=ClasseEnum.Vip},
                new Members() { Id = 02, Nome = "Bruno", Email = "bruno@gmail.com", Nivelconta = 8, Classe=ClasseEnum.Premium},
                new Members() { Id = 03, Nome = "Eduardo", Email = "eduardo@gmail.com", Nivelconta = 6, Classe=ClasseEnum.Vip},
                new Members() { Id = 04, Nome = "Vitor", Email = "vitor@gmail.com", Nivelconta = 4, Classe=ClasseEnum.Premium},
            )
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder ConfigurationBuilder)
        {
            ConfigurationBinder.Properties<string>().HaveColumnTyper("varchar").HaveMaxLength(200);
        }
    }
}