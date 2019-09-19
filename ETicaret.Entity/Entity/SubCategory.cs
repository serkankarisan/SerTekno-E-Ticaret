using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    public class SubCategory:EntityBase
    {
        private string _subCategoryName;

        public string SubCategoryName { get => _subCategoryName; set => _subCategoryName = value; }


    }
}
