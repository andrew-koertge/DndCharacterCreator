using DndCharacterCreator.Models;
using DndCharacterCreator.Services;
using DnDCharacterCreator.Data;
using DnDCharacterCreator.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DnDCharacterCreator.Controllers
{
    [Authorize]
    public class CharacterController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Character
        public ActionResult Index()
        {
            var characterId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(characterId);
            var model = service.GetCharacter();

            return View(model);
        }

        //GET: Character/Create
        public ActionResult Create()
        {
            int[] stats = new int[] { 15, 14, 13, 12, 10, 8 };
            ViewBag.loadStats = stats;
            return View();
        }

        //POST: Character/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterCreate character)
        {
            if (!ModelState.IsValid)
            {
                return View(character);
            }

            var characterId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(characterId);

            service.CreateCharacter(character);
            return RedirectToAction("Index");
        }

        //GET: Character/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        //POST: Character/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Character character = _db.Characters.Find(id);
            _db.Characters.Remove(character);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Character/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        //POST: Character/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Character character)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(character).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(character);
        }

        //GET: Character/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = _db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }
    }
}