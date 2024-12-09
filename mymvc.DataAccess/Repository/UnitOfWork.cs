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

        public ITestRepository Test { get; private set; }
        public IMonitorRepository Monitor { get; private set; }
        public ILecturerRepository Lecturer { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IScheduleRepository Schedule { get; private set; }
        public ICourseRepository Course { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Test = new TestRepository(_db);
            Monitor = new MonitorRepository(_db);
            Lecturer = new LecturerRepository(_db);
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Schedule = new ScheduleRepository(_db);
            Course = new CourseRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
