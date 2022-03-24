using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactBook cbook = new ContactBook();

            cbook.AppInterface();


            /*cbook.CreateContact("Vardges", "Musakhanyan", "091453255", "danoville@gmail.com", "Mikoyan");
            cbook.CreateContact("Hrach", "Asatryan", "077314356", "hrachas48@gmail.com", "Hakob Hakobyan");
            cbook.CreateContact("Mery", "Grigoryan", "098865665", "17 kvartal xz poxocy");
            cbook.CreateContact("Tigran", "Hovhannisyan", "098755712", "tigranhovhannisyanisnotavailable@gmail.com", "Exvardi trass");
            cbook.CreateContact("Anna", "Asatryan", "098979954", "anna.as@gmail.com", "Amerikaner, evropaner, hopefully hayastanner someday");
            cbook.CreateContact("Mesrop", "Andreasyan", "091009511", "mesand@gmail.com", "6rd masiv");
            cbook.CreateContact("Vardan", "Malkhasyan", "097777777", "danoville@gmail.com", "Mikoyan");*/

            cbook.ShowContacts();



           

            Console.ReadKey();
        }
    }
}
