﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mymvc.Models;

namespace mymvc.DataAccess.Repository.IRepository
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        void update(Schedule obj);
    }
}
