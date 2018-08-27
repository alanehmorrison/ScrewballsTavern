using Microsoft.AspNet.Identity;
using Shaker.Model;
using Shaker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shaker.WebMVC
{
    [Authorize]
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InventoryService(userId);
            var model = service.GetInventory();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateInventoryService();
            
             if (service.CreateInventory(model))
            {
                TempData["SaveResult"] = "The input was added to the inventory.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Inventory could not be saved.");

            return View(model);
            
        }

        public ActionResult Details(int id)
        {
            var svc = CreateInventoryService();
            var model = svc.GetInventoryById(id);
            
     return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateInventoryService();
            var detail = service.GetInventoryById(id);
            var model =
                new InventoryEdit
                {
                   InventoryId = detail.InventoryId,
                   InventoryLiquor = detail.InventoryLiquor,
                   InventoryJuice = detail.InventoryJuice,
                   InventoryFruit = detail.InventoryFruit,
                   InventoryOther = detail.InventoryOther
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InventoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.InventoryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateInventoryService();

            if (service.UpdateInventory(model))
            {
                TempData["SaveResult"] = "Your Inventory Addition was saved";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your inventory was not updated. Please try again.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateInventoryService();
            var model = svc.GetInventoryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateInventoryService();

            service.DeleteInventory(id);

            TempData["SaveResult"] = "Your Inventory was deleted.";

            return RedirectToAction("Index");

        }

        private InventoryService CreateInventoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InventoryService(userId);
            return service;
        }



    }
}