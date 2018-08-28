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

        [Display(Name ="Liquor Needed")]
        public string ShoppingLiquor { get; set; }

        [Display(Name ="Juice Needed")]
        public string ShoppingJuice { get; set; }

        [Display(Name ="Fruit Needed")]
        public string ShoppingFruit { get; set; }

        [Display(Name ="Other Items Needed")]
        public string ShoppingOther { get; set; }

        public override string ToString() => ShoppingLiquor;



    }
}
