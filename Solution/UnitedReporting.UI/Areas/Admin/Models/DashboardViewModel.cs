using System.Collections.Generic;
using UnitedReporting.Model;

namespace UnitedReporting.UI.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public IList<TranscriptOrder> TranscriptOrders { get; set; }
        public IList<Contact> Contacts { get; set; }
    }
}