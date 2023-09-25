using MyJourney.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyJourney.Data
{
    public class AppDbContext :IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { 

        }
        public DbSet<Subject> Matric { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
