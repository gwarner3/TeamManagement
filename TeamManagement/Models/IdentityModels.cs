using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TeamManagement.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [RegularExpression(@"^(\d{5})$", ErrorMessage = "Five numbers only")]
        public int? Zip { get; set; }

        public string Phone { get; set; }

        [Display(Name = "Is Injured")]
        public bool IsInjured { get; set; }

        public string Position { get; set; }

        public string Role { get; set; }

        [Display(Name = "Became Player On")]
        public DateTime? PlayerJoinDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<GameScheduleModels> GameSchedules { get; set; }

        public DbSet<AlertModels> Alerts { get; set; }

        public DbSet<RatingModels> Ratings { get; set; }

        public DbSet<AttendanceModels> Attendances { get; set; }

        public DbSet<TrackingModels> Trackings { get; set; }

        public DbSet<MessageModels> Messages { get; set; }

        public DbSet<ApplicationModels> Applicaitons { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}