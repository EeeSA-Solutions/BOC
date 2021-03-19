using BOC.Models;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

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
        public ActionResult GetContact()
        {
            using (var db = new BOCContext())
            {
                var info = db.Contacts.ToList();
                return View(info);
            }
        }


        //lägger till contact i GetContact view
        [HttpPost]
        public ActionResult GetContact(Contact contact)
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
                return RedirectToAction("GetContact");

            }
        }

        [HttpGet]
        public ActionResult AddContact()
        {
                using (var db = new BOCContext())
                {
                    var info = db.Contacts.ToList();
                    return View(info);
                }
        }

        [HttpPost]
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
                return RedirectToAction("AddContact");
                
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

       

        public ActionResult SharedContacts()
        {

            using (var db = new BOCContext())
            {
                var info = db.Contacts.ToList();
                return View(info);
            }
        }

        [HttpGet]
        public ActionResult EditContact(int id)
        {
            using(var db = new BOCContext())
            {
                
                return View(db.Contacts.Where(x => x.ID == id).FirstOrDefault());
            }
           
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact) 
        { 
            using(var db = new BOCContext())
            {
                var cont = db.Contacts.Where(x => x.ID == contact.ID).FirstOrDefault();

                if(contact.Address != null)
                {
                    cont.Address = contact.Address;
                }

                if(contact.Email != null)
                {
                    cont.Email = contact.Email;
                }

                if (contact.Firstname != null)
                {
                    cont.Firstname = contact.Firstname;
                }

                if (contact.Lastname != null)
                {
                    cont.Lastname = contact.Lastname;
                }

                if(contact.Phonenumber != null)
                {
                    cont.Lastname = contact.Lastname;
                }
                
                
                
                db.SaveChanges();

                return RedirectToAction("GetContact");

            }
        }

        //[ActionName("Edit")]
        //public ActionResult Edit(Contact contact)
        //{
        //    using(var db = new BOCContext())
        //    {
        //        db.Contacts.Attach(contact);
        //        db.SaveChanges();
        //        return RedirectToAction("GetContact");
        //    }
        //}
    }
}