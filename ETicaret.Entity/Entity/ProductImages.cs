using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    public class ProductImages:EntityBase
    {
        private string _imagesPath;

        public string ImagesPath { get => _imagesPath; set => _imagesPath = value; }


    }
}
