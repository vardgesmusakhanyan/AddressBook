﻿using System;
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


            cbook.ShowContacts();



           

            Console.ReadKey();
        }
    }
}
