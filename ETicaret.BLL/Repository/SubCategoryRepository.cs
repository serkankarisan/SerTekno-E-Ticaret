using ETicaret.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL.Repository
{
    public class SubCategoryRepository:BaseRepository<SubCategory>
    {
        public List<SubCategory> ListByCategoryId(int CategoryID)
        {
            return _dbSet.Where(w => w.IsActive == true && w.CategoryId == CategoryID).ToList();
        }
        public bool ControlBySubCategoryName(string SubCategoryName)
        {
            bool result = false;
            if (_dbSet.Where(w => w.IsActive == true).FirstOrDefault(x => x.SubCategoryName.ToLower() == SubCategoryName.ToLower()) != null)
            {
                result = true;
            }
            return result;
        }
    }
}
