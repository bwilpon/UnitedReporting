//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitedReporting.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PageContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public bool DisplayImage { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> PublishedDate { get; set; }
        public string FriendlyUrl { get; set; }
        public int CategoryId { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
