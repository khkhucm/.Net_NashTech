using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;

namespace Test.Data.Repositories.Implements
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookLibraryContext context) : base(context)
        {
        }

        public override IEnumerable<Book> GetAll(Expression<Func<Book, bool>>? predicate = null)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return dbSet.Include(book => book.Category).ToList();
        }

        public override Book? Get(Expression<Func<Book, bool>> predicate)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return dbSet.Include(book => book.Category).FirstOrDefault();
        }
    }
}
