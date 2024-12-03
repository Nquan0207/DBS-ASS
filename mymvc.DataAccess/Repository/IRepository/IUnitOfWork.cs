using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mymvc.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITestRepository Test { get; }
        IMonitorRepository Monitor { get; }
        ILecturerRepository Lecturer { get; }
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IScheduleRepository Schedule { get; }
        ICourseRepository Course { get; }
        void Save();
    }
}
