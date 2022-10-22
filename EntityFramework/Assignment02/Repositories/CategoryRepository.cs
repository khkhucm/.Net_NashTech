using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment02.Data;
using Assignment02.Models;

namespace Assignment02.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductStoreContext context) : base(context)
        {
        }
    }
}