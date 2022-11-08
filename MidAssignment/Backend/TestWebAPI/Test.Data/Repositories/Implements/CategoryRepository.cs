using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;

namespace Test.Data.Repositories.Implements
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TestContext context) : base(context)
        {
        }
    }
}
