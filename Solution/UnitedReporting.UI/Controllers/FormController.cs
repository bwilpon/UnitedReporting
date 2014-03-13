using System.Web.Mvc;
using UnitedReporting.DataAccess;
using UnitedReporting.Model;

namespace UnitedReporting.UI.Controllers
{
    public class FormController : Controller
    {
        public ActionResult ScheduleService(string page)
        {
            return View(page);
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult ScheduleService(Contact contact)
        {
            try
            {
                IGenericDataRepository<Contact> contactRepository = new GenericDataRepository<Contact>();
                contactRepository.Add(contact);

                return RedirectToAction("ScheduleService");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult TranscriptOrder()
        {
            return View();
        }
    }
}
