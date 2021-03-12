using BOC.Models;
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