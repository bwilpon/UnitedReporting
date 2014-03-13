using System.Collections.Generic;
using System.Web.Mvc;
using UnitedReporting.DataAccess;
using UnitedReporting.Model;

namespace UnitedReporting.Controllers
{
    public class NavigationController : Controller
    {
        //
        // GET: /Navigation/
        [ChildActionOnly]
        public ActionResult Menu()
        {
            // Get List of Categories and thier associated Pages
            // Get All Categories
            IGenericDataRepository<Category> repository = new GenericDataRepository<Category>();
            IList<Category> categories = repository.GetAll(c => c.Pages);

            //List<Category> categories = new List<Category>
            //    {
            //        new Category { Name = "Home", Page = new Page {FriendlyUrl = "Home"}},
            //        new Category { Name = "Legal Services", 
            //            Pages = new List<Page>
            //            {
            //                new Page { Name = "Court Reporting", FriendlyUrl = "Court-Reporting"},
            //                new Page { Name = "Transcripts", FriendlyUrl = "Court-Reporting"},
            //                new Page { Name = "Videographers", FriendlyUrl = "Court-Reporting"},
            //            }},
            //        new Category { Name = "Locations", 
            //            Pages = new List<Page>
            //            {
            //                new Page { Name = "Fort Lauderdale", FriendlyUrl = "Court-Reporting"},
            //                new Page { Name = "Miami", FriendlyUrl = "Court-Reporting"},
            //            }},
            //        new Category { Name = "Trail Technology", 
            //            Pages = new List<Page>
            //            {
            //                new Page { Name = "Video Services", FriendlyUrl = "Court-Reporting"},
            //                new Page { Name = "Trial Presentation", FriendlyUrl = "Court-Reporting"},
            //                new Page { Name = "Equipment Rental", FriendlyUrl = "Court-Reporting"},
            //            }},
            //        new Category { Name = "About Us", Page = new Page { FriendlyUrl = "About" },
            //            Pages = new List<Page>
            //            {
            //               new Page { Name = "Company History", FriendlyUrl = "Company-History"},
            //               new Page { Name = "Contact Us", FriendlyUrl = "Contact"},
            //               new Page { Name = "About United Reporting", FriendlyUrl = "About"},
            //               new Page { Name = "Home", FriendlyUrl = "Home"},
            //            }},
            //    };
            return PartialView(categories);
        }

    }
}
