using Shaker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Contracts
{
    public interface IRecipeService
    {
        bool CreateRecipe(RecipeCreate model);
        IEnumerable<RecipeListItem> GetRecipes();
        RecipeDetail GetRecipeById(int noteId);
        bool UpdateRecipe(RecipeEdit model);
        bool DeleteRecipe(int noteId);

    }
}
