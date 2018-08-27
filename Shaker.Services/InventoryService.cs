using Shaker.Contracts;
using Shaker.Data;
using Shaker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly Guid _userId;

        public InventoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateInventory(InventoryCreate model)
        {
            var entity =
                new Inventory()
                {
                    OwnerId = _userId,
                    Liquor = model.InventoryLiquor,
                    Fruit = model.InventoryFruit,
                    Juice = model.InventoryJuice,
                    Other = model.InventoryOther
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Inventory.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InventoryListItem> GetInventory()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Inventory
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new InventoryListItem
                                {
                                    InventoryId = e.InventoryId,
                                    InventoryFruit = e.Fruit,
                                    InventoryJuice = e.Juice,
                                    InventoryLiquor = e.Liquor,
                                    InventoryOther = e.Other
                                }
                        );

                return query.ToArray();
            }
        }

        public InventoryDetail GetInventoryById(int inventoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Inventory
                        .Single(e => e.InventoryId == inventoryId && e.OwnerId == _userId);
                return
                    new InventoryDetail
                    {
                        InventoryId = entity.InventoryId,
                        InventoryLiquor = entity.Liquor,
                        InventoryFruit = entity.Fruit,
                        InventoryJuice = entity.Juice,
                        InventoryOther = entity.Other
                    };
            }
        }

        public bool UpdateInventory(InventoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Inventory
                        .Single(e => e.InventoryId == model.InventoryId && e.OwnerId == _userId);
                
                entity.InventoryId = model.InventoryId;
                entity.Liquor = model.InventoryLiquor;
                entity.Juice = model.InventoryJuice;
                entity.Fruit = model.InventoryFruit;
                entity.Other = model.InventoryOther;
                
         return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInventory(int InventoryId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Inventory
                        .Single(e => e.InventoryId == InventoryId && e.OwnerId == _userId);

                ctx.Inventory.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
