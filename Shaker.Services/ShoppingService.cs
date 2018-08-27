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
    public class ShoppingService : IShoppingService
    {
        private readonly Guid _userId;
        
         public ShoppingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShopping(ShoppingCreate model)
        {
            var entity =
                new Shopping()
                {
                    OwnerId = _userId, 
                    ShoppingLiquor = model.ShoppingLiquor,
                    ShoppingFruit = model.ShoppingFruit,
                    ShoppingJuice = model.ShoppingFruit,
                    ShoppingOther = model.ShoppingOther
                };
            
             using (var ctx = new ApplicationDbContext())
            {
                ctx.ShoppingList.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShoppingListItem> GetShopping()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ShoppingList
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ShoppingListItem
                                {
                                    ShoppingId = e.ShoppingId,
                                    ShoppingLiquor = e.ShoppingLiquor,
                                    ShoppingFruit = e.ShoppingFruit,
                                    ShoppingJuice = e.ShoppingJuice,
                                    ShoppingOther = e.ShoppingOther
                                }
                        );

                return query.ToArray();
            }
        }

        public ShoppingDetail GetShoppingById(int shoppingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ShoppingList
                        .Single(e => e.ShoppingId == shoppingId && e.OwnerId == _userId);
                return
                    new ShoppingDetail
                    {
                        ShoppingId = entity.ShoppingId,
                        ShoppingLiquor = entity.ShoppingLiquor,
                        ShoppingFruit = entity.ShoppingFruit,
                        ShoppingJuice = entity.ShoppingJuice,
                        ShoppingOther = entity.ShoppingOther
                    };
            }
        }

        public bool UpdateShopping(ShoppingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ShoppingList
                        .Single(e => e.ShoppingId == model.ShoppingId && e.OwnerId == _userId);
                
                entity.ShoppingId = model.ShoppingId;
                entity.ShoppingLiquor = model.ShoppingLiquor;
                entity.ShoppingJuice = model.ShoppingJuice;
                entity.ShoppingFruit = model.ShoppingFruit;
                entity.ShoppingOther = model.ShoppingOther;
                    
         return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShopping(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ShoppingList
                        .Single(e => e.ShoppingId == noteId && e.OwnerId == _userId);
                
                ctx.ShoppingList.Remove(entity);
                
                return ctx.SaveChanges() == 1;
            }
        }


    }
}
