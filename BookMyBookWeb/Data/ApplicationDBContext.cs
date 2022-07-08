using BookMyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMyBookWeb.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
