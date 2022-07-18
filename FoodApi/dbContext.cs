using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Configuration;

namespace FoodApi.Controllers
{
    public class dbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Booking_list> Booking_list { get; set; }
        public DbSet<Carousel_advertisement> Carousel_advertisement { get; set; }
        public DbSet<Carousel_offers> Carousel_offers { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Restoran> Restoran { get; set; }
        public DbSet<User> User { get; set; }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options) {}

    }
}
