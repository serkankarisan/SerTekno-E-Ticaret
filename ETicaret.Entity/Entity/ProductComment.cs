using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    public class ProductComment:EntityBase
    {
        private string _content;

        public string Content { get => _content; set => _content = value; }

       
    }
}
