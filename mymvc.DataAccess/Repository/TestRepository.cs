using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using mymvc.DataAccess.Data;
using mymvc.DataAccess.Repository.IRepository;
using mymvc.Models;

namespace mymvc.DataAccess.Repository
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        private ApplicationDbContext _db;
        public TestRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Test obj)
        {
            _db.Tests.Update(obj);
        }
    }
}
