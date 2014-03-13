using System.Web.Mvc;
using UnitedReporting.DataAccess;
using UnitedReporting.Model;

namespace UnitedReporting.UI.Controllers
{
    public class PageController : Controller
    {

        public ActionResult Index(string friendlyUrl)
        {
            IGenericDataRepository<PageContent> repository = new GenericDataRepository<PageContent>();
            var page = repository.GetSingle(p => p.FriendlyUrl == friendlyUrl);

            
            ViewBag.Title = page.Name;
            return View(page);
        }


    }
}
