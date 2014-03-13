using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitedReporting.Model
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        //public DbSet<Category> Categories { get; set; }
        //public DbSet<PageContent> PagesContents { get; set; }
    }
}
