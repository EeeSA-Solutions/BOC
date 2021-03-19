using BOC.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace BOC.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult GetContact(string search, string searchBy)
        {
            using (var db = new BOCContext())
            {
                if(searchBy == "Firstname")
                {
                    return View(db.Contacts.Where(c => c.Firstname.StartsWith(search) || search == null).ToList());
                }
                else if(searchBy == "Lastname")
                {
                    return View(db.Contacts.Where(c => c.Lastname.StartsWith(search) || search == null).ToList());
                }
                else if(searchBy == "Phonenumber")
                {
                    return View(db.Contacts.Where(c => c.Phonenumber.StartsWith(search) || search == null).ToList());
                }
                else if(searchBy == "Email")
                {
                    return View(db.Contacts.Where(c => c.Email.StartsWith(search) || search == null).ToList());
                }
                else {  
                    return View(db.Contacts.Where(c => c.Address.StartsWith(search) || search == null).ToList());
                }
            }
        }
        



        //[HttpGet]
        //public ActionResult GetContact(string searchLetter)
        //{
        //    using (var db = new BOCContext())
        //    {
        //        var info = db.Contacts.ToList();
        //        db.Contacts.Where(c => c.Firstname.Contains(searchLetter) || searchLetter == null).ToList()
        //        return View(info);
        //    }
        //}

        public ActionResult AddContact(Contact contact)
        {
            using (var db = new BOCContext())
            {
                if (!ModelState.IsValid)
                {
                    return View(contact);
                }
                db.Contacts.Add(contact);
                db.SaveChanges();
                ModelState.Clear();
                return View();
                
            }
        }

        public ActionResult DeleteContact(int ID)
        {
            using (var db = new BOCContext())
            {
                Contact x = db.Contacts.Find(ID);
                db.Contacts.Remove(x);
                db.SaveChanges();
                return RedirectToAction("GetContact");
            }
        }
    }
}