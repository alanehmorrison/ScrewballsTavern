using Shaker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Contracts
{
    public interface IInventoryService
    {
        bool CreateInventory(InventoryCreate model);
        IEnumerable<InventoryListItem> GetInventory();
        InventoryDetail GetInventoryById(int inventoryId);
        bool UpdateInventory(InventoryEdit model);
        bool DeleteInventory(int InventoryId);



    }
}
