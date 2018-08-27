using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Data
{
    public class Shopping
    {
        [Key]
        public int ShoppingId { get; set; }

        public Guid OwnerId { get; set; }

        public string ShoppingLiquor { get; set; }
        public string ShoppingJuice { get; set; }
        public string ShoppingFruit { get; set; }
        public string ShoppingOther { get; set; }

    }
}
