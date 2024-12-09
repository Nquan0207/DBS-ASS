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
    public class LecturerRepository : Repository<Lecturer>, ILecturerRepository
    {
        private ApplicationDbContext _db;
        public LecturerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Lecturer obj)
        {
            _db.Lecturers.Update(obj);
        }
    }
}
