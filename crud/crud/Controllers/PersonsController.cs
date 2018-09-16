using crud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Persons
        CrudContext db = new CrudContext();
        public ActionResult Index()
        {
            var person = db.Person.ToList();
            return View(person);
        }
        public ActionResult Details(int? Id)
        {
            Person person = db.Person.Find(Id);
            return View(person);
                
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            Person person = db.Person.Find(id);
            return View(person);
        }
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int? id)
        {

            Person person = db.Person.Find(id);
            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Person person = db.Person.Find(id);
                db.Entry(person).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}