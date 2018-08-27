using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Model
{
    public class InventoryDetail
    { 
        public int InventoryId { get; set; }

        [Display(Name = "Liquor I Have")]
        public string InventoryLiquor { get; set; }

        [Display(Name = "Juice I Have")]
        public string InventoryJuice { get; set; }

        [Display(Name = "Fruit I Have")]
        public string InventoryFruit { get; set; }

        [Display(Name = "Other Items")]
        public string InventoryOther { get; set; }

        public override string ToString() => $"[{InventoryId}] {InventoryLiquor}";

    }
}
