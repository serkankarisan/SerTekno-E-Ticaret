using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaret.PL.Models
{
    public class BrandViewModel
    {
        public string BrandName { get; set; }
        public int ModelCount { get; set; }

        public override string ToString()
        {
            return BrandName;
        }
    }
}