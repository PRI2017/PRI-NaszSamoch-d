using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PRI_NaszSamochód.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<FriendModel> Friends { get; set; }
        public DbSet<GroupModel> Groups { get; set; }

    }
}