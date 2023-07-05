using Microsoft.EntityFrameworkCore;

namespace ApiGlobaltecDev.Models
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options) { }
        public DbSet<PessoasModel> Pessoas { get; set; }
        public DbSet<ContasPagasModel> ContasPagas { get; set; }
        public DbSet<ContasAPagarModel> ContasAPagar { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    DbContextOptionsBuilder dbContextOptionsBuilder = optionsBuilder.UseSqlServer("ConnectionBase");
        //    // Definindo a string de conexão com o seu banco de dados

        //}

        public IEnumerable<object> PessoasModel { get; internal set; }
        public IEnumerable<object> ContasApagarModel { get; internal set; }
        public IEnumerable<object> ContasPagasModel { get; internal set; }

        internal object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
