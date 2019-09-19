using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    public class Model:EntityBase
    {
        private string _modelName;

        public string ModelName { get => _modelName; set => _modelName = value; }


    }
}
