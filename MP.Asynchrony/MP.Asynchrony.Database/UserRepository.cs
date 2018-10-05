using MP.Asynchrony.Database.Models;

namespace MP.Asynchrony.Database
{
    public class UserRepository : Repository<User>
    {
        public UserRepository() : base(new Context()) { }
    }
}
