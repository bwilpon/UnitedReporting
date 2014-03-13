using System.Collections.Generic;
using System.Web.Mvc;
using UnitedReporting.Business;
using UnitedReporting.Model;

namespace UnitedReporting.UI.Controllers
{
    public class NavigationController : Controller
    {
        //
        // GET: /Navigation/
        [ChildActionOnly]
        public ActionResult Menu()
        {
            // Get List of Categories and thier associated Pages
            var categories = new CategoryManager().GetNavigation();
            return PartialView(categories);
        }
    }
}
