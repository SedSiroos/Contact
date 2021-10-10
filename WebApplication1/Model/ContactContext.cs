using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
