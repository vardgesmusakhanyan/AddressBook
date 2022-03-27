using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DbContexts
{
    class ContactBookDbContext : DbContext
    {
        public ContactBookDbContext(string connectionString)
            : base(connectionString)
        {
            
        }

        public DbSet<Contact> Contacts { get; set ; }
    }
}
