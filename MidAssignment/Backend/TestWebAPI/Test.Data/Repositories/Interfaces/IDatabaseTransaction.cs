using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Repositories.Interfaces
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();
        void RollBack();
    }
}
