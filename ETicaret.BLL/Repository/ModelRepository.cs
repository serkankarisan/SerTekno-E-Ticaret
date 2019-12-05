using ETicaret.Entity.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ETicaret.BLL.Repository
{
    public class ModelRepository : BaseRepository<Model>
    {
        public List<Model> ListByBrandId(int BrandID)
        {
            return _dbSet.Where(w => w.IsActive == true && w.BrandId == BrandID).ToList();
        }
        public bool ControlByModelName(string ModelName)
        {
            bool result = false;
            if (_dbSet.Where(w => w.IsActive == true).FirstOrDefault(x => x.ModelName.ToLower() == ModelName.ToLower()) != null)
            {
                result = true;
            }
            return result;
        }
    }
}
