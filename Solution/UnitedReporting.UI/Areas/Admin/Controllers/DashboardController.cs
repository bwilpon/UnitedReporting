using System.Web.Mvc;
using UnitedReporting.DataAccess;
using UnitedReporting.Model;
using UnitedReporting.UI.Areas.Admin.Models;

namespace UnitedReporting.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IGenericDataRepository<Contact> _contactRepository;
        private readonly IGenericDataRepository<TranscriptOrder> _transcriptOrderRepository; 
        public DashboardController()
        {
            _contactRepository = new GenericDataRepository<Contact>();
            _transcriptOrderRepository = new GenericDataRepository<TranscriptOrder>();
        }

        public ActionResult Index()
        {
            var contacts = _contactRepository.GetAll();
            var orders = _transcriptOrderRepository.GetAll();
            var viewModel = new DashboardViewModel
            {
                Contacts = contacts,
                TranscriptOrders = orders
            };
            return View(viewModel);
        }

        public ActionResult ScheduleServiceDetails(int id)
        {
            var contact = _contactRepository.GetSingle(c => c.Id == id);
            return View(contact);
        }

    }
}
