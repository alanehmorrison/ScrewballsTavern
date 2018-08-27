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
        public string RecipeName { get; set; }

        [Required]
        public string RecipeIngredients { get; set; }

        [Required]
        public string RecipeInstructions { get; set; }

        public override string ToString() => RecipeName; 
    }
}
