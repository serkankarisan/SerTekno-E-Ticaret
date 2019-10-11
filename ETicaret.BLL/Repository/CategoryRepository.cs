﻿using ETicaret.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL.Repository
{
    public class CategoryRepository:BaseRepository<Category>
    {
        public bool ControlByCategoryName(string CategoryName)
        {
            bool result = false;
            if (_dbSet.Where(w => w.IsActive == true).FirstOrDefault(x => x.CategoryName.ToLower() == CategoryName.ToLower()) != null)
            {
                result = true;
            }
            return result;
        }
    }
}
