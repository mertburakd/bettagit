using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using static BettaPlanet.Models.Entities;

namespace BettaPlanet.Models
{
    public partial class Context : DbContext
    {
        static Context()
        {
            Database.SetInitializer<Context>(null);
        }
        public Context()
        : base("name=bettadata")
        { }

        public DbSet<URUNLER> urunler { get; set; }
        public DbSet<about> about { get; set; }


    }
}