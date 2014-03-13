using System.Web.Mvc;
using UnitedReporting.DataAccess;
using UnitedReporting.Model;

namespace UnitedReporting.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IGenericDataRepository<Contact> _contactRepository;

        public DashboardController()
        {
            _contactRepository = new GenericDataRepository<Contact>();
        }

        public ActionResult Index()
        {
            var contacts = _contactRepository.GetAll();
            return View(contacts);
        }

        public ActionResult Details(int id)
        {
            var contact = _contactRepository.GetSingle(c => c.Id == id);
            return View(contact);
        }

    }
}
