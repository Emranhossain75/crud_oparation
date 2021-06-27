using CRUD_OPARATION.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_OPARATION.Controllers
{

    public class StudentController : Controller
    {
        CRUDEntities obj = new CRUDEntities();
        // GET: Student
        public ActionResult Index(Student_Information student)
        {
           
                return View(student);
        }
        [HttpPost]
        public ActionResult AddStudent(Student_Information model)
        {

            Student_Information db = new Student_Information();
            if (ModelState.IsValid)
            {
                db.ID = model.ID;
                db.FastName = model.FastName;
                db.LastName = model.LastName;
                db.Email = model.Email;
                db.Phone = model.Phone;
                db.Description = model.Description;
                if (model.ID == 0)
                {
                   obj.Student_Information.Add(db);
                   obj.SaveChanges();
                }
                else
                {
                    obj.Entry(db).State = EntityState.Modified;
                    obj.SaveChanges();
                }
            
            }
            ModelState.Clear();
         
            return View("Index");
        }

        public ActionResult liststudent()
        {
            var res = obj.Student_Information.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = obj.Student_Information.Where(x=>x.ID==id).First();
            obj.Student_Information.Remove(res);
            obj.SaveChanges();
            var list = obj.Student_Information.ToList();
            return View("liststudent",list);
        }


    }
}