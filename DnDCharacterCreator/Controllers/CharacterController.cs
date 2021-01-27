using DndCharacterCreator.Models;
using DndCharacterCreator.Models.CharacterModels;
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

            var characterId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(characterId);
            
            //service.CreateSkills();
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
        public ActionResult Delete()
        {
            return View();           
        }

        //POST: Character/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var characterId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(characterId);
            service.Delete(id);
            return RedirectToAction("Index");
        }

        //GET: Character/Edit/{id}
        public ActionResult Edit()
        {
            return View();
        }

        //POST: Character/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id)
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }

            var characterId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(characterId);
            service.Edit((int)id);
            return RedirectToAction("Index");
        }

        //GET: Character/Details/{id}
        public ActionResult Details(int id)
        {
            var characterId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(characterId);
            var model = service.Details(id);
            return View(model);
        }
    }
}