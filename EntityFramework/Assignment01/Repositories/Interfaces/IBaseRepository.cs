using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Assignment01.Models;

namespace Assignment01.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity<int>
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        T? Get(Expression<Func<T, bool>> predicate);
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        int SaveChanges();
    }
}