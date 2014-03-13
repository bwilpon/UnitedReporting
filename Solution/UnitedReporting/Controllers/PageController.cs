using System.Collections.Generic;
using System.Web.Mvc;
using UnitedReporting.Model;

namespace UnitedReporting.Controllers
{
    public class PageController : Controller
    {

        public ActionResult Index(string friendlyUrl)
        {
            Page page;

            switch (friendlyUrl)
            {
                case "About":
                    page = new Page
                        {
                            Name = "About Us",
                            SubTitle = "Over 25 Years of Experience",
                            Body = "<p>United Reporting, Inc. is an independently owned and operated firm located in downtown Fort Lauderdale, minutes from the airport. We are a full-service court reporting and video agency specializing in complex litigation. Professional services include quick turn-around/delivery, real-time, LiveNote, rough ASCII disks, video synchronization.</p><p>Serving all of Broward, Dade and Palm Beach Counties, with free deposition suites in Fort Lauderdale (Broward), North Miami & downtown Miami (Dade), and Boca Raton & West Palm Beach (Palm Beach).</p>",
                            DisplayImage = true,
                            ImageUrl = "/Images/page-placeholder.jpg"
                        };
                    break;
                default:
                    page = new Page
                        {
                            Name = "United Reporting",
                            SubTitle = "Over 25 Years of Experience",
                            Body = "<p>United Reporting, Inc. is an independently owned and operated firm located in downtown Fort Lauderdale, minutes from the airport. We are a full-service court reporting and video agency specializing in complex litigation. Professional services include quick turn-around/delivery, real-time, LiveNote, rough ASCII disks, video synchronization.</p>",
                            DisplayImage = true,
                            ImageUrl = "/Images/page-placeholder.jpg",
                        };
                    break;
            }
            ViewBag.Title = page.Name;
            return View(page);
        }

        
    }
}
