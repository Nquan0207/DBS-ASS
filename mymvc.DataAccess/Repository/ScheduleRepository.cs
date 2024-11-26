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
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        private ApplicationDbContext _db;
        public ScheduleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Schedule obj)
        {
            var objFromDb = _db.Schedules.FirstOrDefault(u => u.ScheduleId == obj.ScheduleId);
            if (objFromDb != null)
            {
                objFromDb.CourseId = obj.CourseId;
                objFromDb.Time = obj.Time;
                objFromDb.Date = obj.Date;
                objFromDb.Location = obj.Location;
            }
        }
    }
}
