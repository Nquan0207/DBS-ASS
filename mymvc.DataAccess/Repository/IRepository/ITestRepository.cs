using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mymvc.Models;

namespace mymvc.DataAccess.Repository.IRepository
{
    public interface ITestRepository : IRepository<Test>
    {
        void update(Test obj);
    }
}
