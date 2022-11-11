using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;

namespace Test.Data.Repositories.Implements
{
    public class BookRequestRepository : BaseRepository<BookRequest>, IBookRequestRepository
    {
        public BookRequestRepository(BookLibraryContext context) : base(context)
        {
        }

        public override IEnumerable<BookRequest> GetAll(Expression<Func<BookRequest, bool>>? predicate = null)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return dbSet
                .Include(br => br.RequestedByUser)
                .Include(br => br.ApprovalModifiedByUser)
                .Include(br => br.BookRequestDetails)
                .ToList();
        }

        public override BookRequest? Get(Expression<Func<BookRequest, bool>> predicate)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return dbSet
                .Include(br => br.RequestedByUser)
                .Include(br => br.ApprovalModifiedByUser)
                .Include(br => br.BookRequestDetails)
                .FirstOrDefault();
        }
    }
}
