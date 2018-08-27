using Microsoft.AspNet.Identity;
using Shaker.Model;
using Shaker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shaker.WebMVC.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            var model = service.GetRecipes();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRecipeService();

            if (service.CreateRecipe(model))
            {
                TempData["SaveResult"] = "Your Recipe was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Recipe could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);
            
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRecipeService();
            var detail = service.GetRecipeById(id);
            var model =
                new RecipeEdit
                {
                    RecipeId = detail.RecipeId,
                    RecipeName = detail.RecipeName,
                    RecipeIngredients = detail.RecipeIngredients,
                    RecipeInstructions = detail.RecipeInstructions
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeEdit model)
        {
            if(!ModelState.IsValid) return View(model);
            
            if (model.RecipeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateRecipeService();
            
            if (service.UpdateRecipe(model))
            {
                TempData["SaveResult"] = "Your Recipe was updated.";
                return RedirectToAction("Index");
            }
     
            ModelState.AddModelError("", "Your Recipe could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        { 
            var service = CreateRecipeService();
            
             service.DeleteRecipe(id);
            
            TempData["SaveResult"] = "Your note was deleted";
            
            return RedirectToAction("Index");
        }




        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            return service;
        }
    }
}