using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    public class Brand:EntityBase
    {
        private string _brandName;

        public string BrandName { get => _brandName; set => _brandName = value; }


    }
}
