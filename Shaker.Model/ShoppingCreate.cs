using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Model
{
    public class ShoppingCreate
    {
        public int ShoppingId { get; set; }
        public string ShoppingLiquor { get; set; }
        public string ShoppingJuice { get; set; }
        public string ShoppingFruit { get; set; }
        public string ShoppingOther { get; set; }

        public override string ToString() => ShoppingLiquor;



    }
}
