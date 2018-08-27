using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public string RecipeName { get; set; }

        [Required]
        public string RecipeIngredients { get; set; }

        [Required]
        public string RecipeInstructions { get; set; }
    }
}
