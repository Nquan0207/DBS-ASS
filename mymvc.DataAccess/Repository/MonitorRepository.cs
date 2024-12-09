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
    public class MonitorRepository : Repository<Models.Monitor>, IMonitorRepository
    {
        private ApplicationDbContext _db;
        public MonitorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Models.Monitor obj)
        {
            _db.Monitors.Update(obj);
        }
    }
}
