using MP.Asynchrony.Database.Models;
using System.Data.Entity;

namespace MP.Asynchrony.Database
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(string connectionString) { }

        public DbSet<User> Users { get; set; }
    }
}
