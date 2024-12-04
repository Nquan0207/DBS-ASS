using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mymvc.DataAccess.Data;
using mymvc.DataAccess.Repository.IRepository;
using mymvc.Models;

namespace mymvc.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IScheduleRepository Schedule { get; private set; }
        public ICourseRepository Course { get; private set; }
        public IStudentRepository Student { get; private set; }//
        public ICreateScheduleRepository CreateSchedule { get; private set; }//



        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Schedule = new ScheduleRepository(_db);
            Course = new CourseRepository(_db);
            Student = new StudentRepository(_db);           //
            CreateSchedule = new CreateScheduleRepository(_db);           //
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
