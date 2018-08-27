using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Model
{
    public class RecipeEdit
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeIngredients { get; set; }
        public string RecipeInstructions { get; set; }

    }
}
