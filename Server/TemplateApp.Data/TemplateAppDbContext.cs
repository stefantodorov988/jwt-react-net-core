using Microsoft.EntityFrameworkCore;
using TemplateApp.Data.Models;

namespace TemplateApp.Data
{
    public class TemplateAppDbContext : DbContext
    {
        public TemplateAppDbContext(DbContextOptions<TemplateAppDbContext> options)
          : base(options)
        { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<IpAdress> IpAdresses{ get; set; }
        public DbSet<PageStatistics> PageStatistics{ get; set; }
        public DbSet<UniqueClick> UniqueClicks{ get; set; }
    }
}
