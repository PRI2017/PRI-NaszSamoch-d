using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PRI_NaszSamochód.Models
{
    public class Context : DbContext
    {
        public DbSet<MobileLoginModel> mobileLoginModel { get; set; }
        public static Context Create()
        {
            return new Context();
        }
    }
}