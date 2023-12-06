using EventRegistration.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventRegistration.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
