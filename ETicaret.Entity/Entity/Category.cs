using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    public class Category:EntityBase
    {
        private string _categoryName;

        public string CategoryName { get => _categoryName; set => _categoryName = value; }


    }
}
