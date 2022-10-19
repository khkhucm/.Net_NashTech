using System.Linq.Expressions;
using Assignment01.Models;
using Assignment01.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Assignment01.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<int>
    {
        private readonly DbSet<T> _dbSet;
        private readonly StudentContext _context;

        public BaseRepository(StudentContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public T Create(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);

            return true;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }
    }
}