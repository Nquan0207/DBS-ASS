﻿using System;
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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
