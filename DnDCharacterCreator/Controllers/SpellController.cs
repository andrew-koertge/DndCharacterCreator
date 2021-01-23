using DndCharacterCreator.Models.SpellModels;
using DndCharacterCreator.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DnDCharacterCreator.Controllers
{
    [Authorize]
    public class SpellController : Controller
    {
        // GET: Spell
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpellService(userId);
            var model = service.GetSpells();

            return View(model);
        }

        //GET: Spell/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Spell/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpellCreate spell)
        {
            if (!ModelState.IsValid)
            {
                return View(spell);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpellService(userId);

            service.CreateSpell(spell);
            return RedirectToAction("Index");
        }

        //GET: Spell/Details/{id}
        public ActionResult Details(int? id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpellService(userId);
            var model = service.Details((int)id);
            return View(model);
        }

        //GET: Spell/Edit/{id}
        public ActionResult Edit()
        {
            return View();
        }

        //POST: Spell/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpellService(userId);
            var model = service.Edit((int)id);
            return View(model);
        }

        //POST: Spell/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SpellService(userId);
            service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}