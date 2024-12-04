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
    public class CreateScheduleRepository : Repository<Models.CreateSchedule>, ICreateScheduleRepository
    {
        private ApplicationDbContext _db;
        public CreateScheduleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Models.CreateSchedule obj)
        {
            _db.CreateSchedules.Update(obj);
        }
    }
}
