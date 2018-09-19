using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HouseProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("FirstName", this.FirstName));
            userIdentity.AddClaim(new Claim("LastName", this.LastName));
            userIdentity.AddClaim(new Claim("Birthdate", this.Birthdate.Value.ToShortDateString()));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Home> Homes { get; set; }
        public DbSet<BookingRecord> BookingRecords { get; set; }
        public DbSet<HostRequest> HostRequests { get; set; }
        public DbSet<HouseImage> HouseImages { get; set; }
        public DbSet<HomeType> HomeTypes { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<SelectedAmenity> SelectedAmenities { get; set; }

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