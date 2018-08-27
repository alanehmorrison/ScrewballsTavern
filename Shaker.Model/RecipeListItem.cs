using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Model
{
    public class RecipeListItem
    {
        public int RecipeId { get; set; }

        [Display(Name = "Name of Recipe")]
        public string RecipeName { get; set; }

        [Display(Name = "Ingredients You Will Need")]
        public string RecipeIngredients { get; set; }

        [Display(Name = "Instructions")]
        public string RecipeInstructions { get; set; }

        public override string ToString() => RecipeName; 
    }
}
