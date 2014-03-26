using System;
using System.Linq;
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
        public ActionResult ScheduleService(Contact contact, FormCollection collection)
        {
            try
            {
                IGenericDataRepository<Contact> contactRepository = new GenericDataRepository<Contact>();
                var services = collection["RequestedServices"].Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                contact.RequestedServices = string.Join(", ", services);
                contactRepository.Add(contact);
                //TODO: Send email
                //TODO: Redirect to thank you page
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

        [HttpPost]
        public ActionResult TranscriptOrder(TranscriptOrder order)
        {
            try
            {
                IGenericDataRepository<TranscriptOrder> repository = new GenericDataRepository<TranscriptOrder>();
                repository.Add(order);
                //TODO: Send email
                //TODO: Redirect to thank you page
                return RedirectToAction("TranscriptOrder");
            }
            catch
            {
                return View();
            }
        }
    }
}
