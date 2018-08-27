using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Data
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        public Guid OwnerId { get; set; }

        public string Liquor { get; set; }
        public string Juice { get; set; }
        public string Fruit { get; set; }
        public string Other { get; set; }
    }
}
