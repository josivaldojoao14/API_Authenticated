using Microsoft.EntityFrameworkCore;

namespace RestWith.NET5.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {  }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
