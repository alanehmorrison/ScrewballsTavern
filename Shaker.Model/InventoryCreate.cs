using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Model
{
    public class InventoryCreate
    {
        [Display(Name ="Liquor Inventory")]
        public string InventoryLiquor { get; set; }

        [Display(Name ="Juice Inventory")]
        public string InventoryJuice { get; set; }

        [Display(Name ="Fruit Inventory")]
        public string InventoryFruit { get; set; }

        [Display(Name ="Other Inventory")]
        public string InventoryOther { get; set; }

        public override string ToString() => InventoryLiquor;

    }
}
