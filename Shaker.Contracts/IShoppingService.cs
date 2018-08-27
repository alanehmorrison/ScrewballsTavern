using Shaker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Contracts
{
    public interface IShoppingService
    {
        bool CreateShopping(ShoppingCreate model);
        IEnumerable<ShoppingListItem> GetShopping();
        ShoppingDetail GetShoppingById(int shoppingId);
        bool UpdateShopping(ShoppingEdit model);
        bool DeleteShopping(int noteId);

    }
}
