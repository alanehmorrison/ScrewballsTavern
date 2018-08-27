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
    public class RecipeService : IRecipeService
    {
        private readonly Guid _userId;

        public RecipeService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateRecipe(RecipeCreate model)
        {
            var entity =
                new Recipe()
                {
                    OwnerId = _userId,
                    RecipeName = model.RecipeName,
                    RecipeIngredients = model.RecipeIngredients,
                    RecipeInstructions = model.RecipeInstructions
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeId = e.RecipeId,
                                    RecipeName = e.RecipeName,
                                    RecipeIngredients = e.RecipeIngredients,
                                    RecipeInstructions = e.RecipeInstructions
                                }
                        );

                return query.ToArray();
            }
        }

        public RecipeDetail GetRecipeById(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == noteId && e.OwnerId == _userId);
                return
                    new RecipeDetail
                    {
                        RecipeId = entity.RecipeId,
                        RecipeName = entity.RecipeName,
                        RecipeIngredients = entity.RecipeIngredients,
                        RecipeInstructions = entity.RecipeInstructions,
                    };
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == model.RecipeId && e.OwnerId == _userId);

                entity.RecipeName = model.RecipeName;
                entity.RecipeIngredients = model.RecipeIngredients;
                entity.RecipeInstructions = model.RecipeInstructions;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                       ctx
                           .Recipes
                           .Single(e => e.RecipeId == noteId && e.OwnerId == _userId);
                            
                 ctx.Recipes.Remove(entity);
                
                return ctx.SaveChanges() == 1;
            }
        }
    }
}