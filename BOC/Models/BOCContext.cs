using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BOC.Models
{
    public class BOCContext : DbContext
    {
        public BOCContext() : base("name=BOCConnectionsString") { }

        public DbSet<Contact> Contacts { get; set; }

    }
}