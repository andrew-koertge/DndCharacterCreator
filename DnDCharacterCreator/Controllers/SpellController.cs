using DndCharacterCreator.Models.SpellModels;
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
            return View();
        }

        //GET: Spell/Create
        public ActionResult Create()
        {

        }

        //POST: Spell/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpellCreate spell)
        {

        }

        //GET: Spell/Details/{id}
        public ActionResult Details()
        {

        }

        //GET: Spell/Edit/{id}
        public ActionResult Edit()
        {

        }

        //POST: Spell/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {

        }

        //GET: Spell/Delete/{id}
        public ActionResult Delete()
        {

        }

        //POST: Spell/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {

        }
    }
}