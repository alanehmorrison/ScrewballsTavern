using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Model
{
    public class RecipeDetail
    {
        [Display(Name = "Recipe Id")]
        public int RecipeId { get; set; }

        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }

        [Display(Name = "Ingredients")]
        public string RecipeIngredients { get; set; }

        [Display(Name = "Ingredients")]
        public string RecipeInstructions { get; set; }

        public override string ToString() => $"[{RecipeId}] {RecipeName}";
    }
}

