using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UnitedReporting.Model
{
    [MetadataType(typeof(ContactMetadata))]
    public partial class Contact { }

    public class ContactMetadata
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string AttorneyFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string AttorneyLastName { get; set; }

        [Required]
        [Display(Name = "Firm Name")]
        public string FirmName { get; set; }

        [Display(Name = "Notes")]
        [Description("You may enter any additional instructions, information, requirements or comments.")]
        public string Message { get; set; }
    }
}
