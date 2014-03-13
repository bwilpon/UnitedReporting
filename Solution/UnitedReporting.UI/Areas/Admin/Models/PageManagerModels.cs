using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using UnitedReporting.Model;

namespace UnitedReporting.UI.Areas.Admin.Models
{
    public class PageManagerPageViewModel
    {
        public PageContent PageContent { get; set; }
        public IList<Category> Categories { get; set; }
    }
}