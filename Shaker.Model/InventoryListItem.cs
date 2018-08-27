using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Model
{
    public class InventoryListItem
    {
        public int InventoryId { get; set; }

        [Display(Name = "Liquor Needed")]
        public string InventoryLiquor { get; set; }

        [Display(Name = "Juice Needed")]
        public string InventoryJuice { get; set; }

        [Display(Name = "Fruit Needed")]
        public string InventoryFruit { get; set; }

        [Display(Name = "Other Items Needed")]
        public string InventoryOther { get; set; }

        public override string ToString() => InventoryLiquor;
    }
}
