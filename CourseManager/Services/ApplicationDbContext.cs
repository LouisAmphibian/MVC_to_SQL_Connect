using CourseManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CourseManager.Services
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
    }
}
