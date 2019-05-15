using Microsoft.EntityFrameworkCore;
using TemplateApp.Data.Models;

namespace TemplateApp.Data
{
    public class TemplateAppDbContext : DbContext
    {
        public TemplateAppDbContext(DbContextOptions<TemplateAppDbContext> options)
          : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
