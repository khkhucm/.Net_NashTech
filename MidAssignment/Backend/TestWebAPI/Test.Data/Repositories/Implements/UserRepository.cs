using System.Linq.Expressions;
using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;

namespace Test.Data.Repositories.Implements
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BookLibraryContext context) : base(context)
        {
        }

        public override User? Get(Expression<Func<User, bool>> predicate)
        {
            return predicate == null ? _dbSet.SingleOrDefault() : _dbSet.SingleOrDefault(predicate);
        }
    }
}
