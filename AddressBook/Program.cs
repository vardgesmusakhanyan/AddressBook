using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.DbContexts;
using AddressBook.Services;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            ContactBook cbook = new ContactBook(new SqlDbService(new ContactBookDbContext(connectionString)));

            cbook.Run();
        }
    }
}
