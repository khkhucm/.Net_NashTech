using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;

namespace Test.Data.Repositories.Implements
{
    public class BookRequestDetailRepository : BaseRepository<BookRequestDetail>, IBookRequestDetailRepository
    {
        public BookRequestDetailRepository(BookLibraryContext context) : base(context)
        {
        }

        public override IEnumerable<BookRequestDetail> GetAll(Expression<Func<BookRequestDetail, bool>>? predicate = null)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return dbSet
                .Include(bd => bd.Book)
                .Include(bd => bd.BookRequest)
                .ToList();
        }

        public override BookRequestDetail? Get(Expression<Func<BookRequestDetail, bool>> predicate)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return dbSet
                .Include(bd => bd.Book)
                .Include(bd => bd.BookRequest)
                .FirstOrDefault();
        }
    }
}
