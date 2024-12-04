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
    public class StudentRepository : Repository<Student>, IStudentRepository          //
    {
        private ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Student obj)             //
        {
            _db.Students.Update(obj);   
        }
    }
}
