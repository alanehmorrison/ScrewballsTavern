using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Model
{
    public class RecipeCreate
    {
        [Required]
        [Display(Name ="Recipe Name")]
        public string RecipeName { get; set; }

        [Required]
        [Display(Name ="Recipe Ingredients")]
        public string RecipeIngredients { get; set; }

        [Required]
        [Display(Name ="Instructions")]
        public string RecipeInstructions { get; set; }

        public override string ToString() => RecipeName; 
    }
}
