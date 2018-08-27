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

        public string InventoryLiquor { get; set; }
        public string InventoryJuice { get; set; }
        public string InventoryFruit { get; set; }
        public string InventoryOther { get; set; }

        public override string ToString() => InventoryLiquor;

    }
}
