using Rejestr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.Logic.LostProcessor;

namespace Rejestr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Lista()
        {
            ViewBag.Message = "Lista zaginionych";

            var data = LoadLost();
            List<LostModel> lost = new List<LostModel>();

            foreach (var row in data)
            {
                lost.Add(new LostModel
                {
                    Id = row.Id,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Age = row.Age,
                    Gender = (GenderEnum)row.Gender
                }) ;
            }

            return View(lost);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize(Roles = "user, admin")]
        public ActionResult Dodaj()
        {
            ViewBag.Message = "Dodaj zaginiona osobe do listy";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dodaj(LostModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateLost(model.FirstName, model.LastName, model.Age, (DataLibrary.Models.GenderEnum)model.Gender);
                return RedirectToAction("Lista");
            }

            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int Id)
        {
            var data = LoadLost();

            var find = data.Where(x => x.Id == Id).FirstOrDefault();


            return View(new LostModel
            {
                Id = find.Id,
                FirstName = find.FirstName,
                LastName = find.LastName,
                Age = find.Age,
                Gender = (GenderEnum)find.Gender
            });
        }
        [HttpPost]
        public ActionResult Edit(int Id, LostModel lostmodel)
        {
             EditLost(Id, lostmodel.FirstName,lostmodel.LastName,lostmodel.Age, (DataLibrary.Models.GenderEnum)lostmodel.Gender);

            
            return RedirectToAction("Lista");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int Id)
        {
            var data = LoadLost();

            var find = data.Where(x => x.Id == Id).FirstOrDefault();


            return View(new LostModel
            {
                Id = find.Id,
                FirstName = find.FirstName,
                LastName = find.LastName,
                Age = find.Age,
                Gender = (GenderEnum)find.Gender
            });
        }
        [HttpPost]
        public ActionResult Delete(int Id, LostModel lostmodel)
        {
            Deletesql(Id, lostmodel.FirstName, lostmodel.LastName, lostmodel.Age, (DataLibrary.Models.GenderEnum)lostmodel.Gender);
            return RedirectToAction("Lista");
        }
    }
}