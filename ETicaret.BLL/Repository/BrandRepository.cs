using ETicaret.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL.Repository
{
    public class BrandRepository:BaseRepository<Brand>
    {
        public Brand SelectByBrandName(string BrandName)
        {
           return _dbSet.Where(w => w.IsActive == true).FirstOrDefault(x => x.BrandName.ToLower() == BrandName.ToLower());
        }
        public bool ControlByBrandName(string BrandName)
        {
            bool result = false;
            if (_dbSet.Where(w => w.IsActive == true).FirstOrDefault(x => x.BrandName.ToLower() == BrandName.ToLower())!=null)
            {
                result = true;
            }
            return result;
        }
    }
}
