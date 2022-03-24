using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class ContactBook
    {
        private List<Contact> Contacts = new List<Contact>();


        public List<Contact> GetContacts()
        {
            if (Contacts.Count == 0)
            {
                Console.WriteLine("Your contacts list is empty");
                Console.ReadKey();
            }
            return Contacts;
        }

        public void AppInterface()
        {
            Console.WriteLine("Type help to see the available commands, or type quit to exit the program");
            string str = "  ";

            while (str.ToLower() != "quit")
            {
                str = Console.ReadLine();

                if (str.ToLower() == "help")
                {
                    Console.WriteLine("The available commands are:");
                    Console.WriteLine("Showcontacts to see all your contacts");
                    Console.WriteLine("CreateContact to create a new contact");
                    Console.WriteLine("EditContact to edit an existing contact");
                    Console.WriteLine("DeleteContact to delete an existing contact");
                    Console.WriteLine("Quit to close the app");

                }


                else if (str.ToLower() != "quit")
                {
                    switch (str.ToLower())
                    {
                        case "showcontacts":
                            this.ShowContacts();
                            break;
                        case "viewcontact":
                            this.ViewContact();
                            break;
                        case "createcontact":
                            this.CreateContact();
                            break;
                        case "editcontact":
                            this.EditContact();
                            break;
                        case "deletecontact":
                            this.DeleteContact();
                            break;
                        default:
                            break;
                    }

                }

                else if (str.ToLower() == "quit")
                    Environment.Exit(0);

                else
                {
                    Console.WriteLine("Invalid command, try typing Help");
                }

            }

        }


        public void ShowContacts()
        {
            int i = 1;
            Console.WriteLine("There are {0} contacts in your contact list", Contacts.Count(), " printing them below");
            foreach (Contact contact in Contacts)
            {
                Console.WriteLine("Contact number {0}", i);
                PrintContact(contact);
                i++;
            }
        }

        public void ViewContact()
        {
            Console.WriteLine("Please type the name of the contact or the number");
            string name = Console.ReadLine();

            bool b = false;

            foreach (Contact contact in Contacts)
            {
                if (contact.Name.ToLower().Contains(name.ToLower()))
                {
                    b = true;
                    PrintContact(contact);
                }

                if (contact.Number.Contains(name))
                {
                    b = true;
                    PrintContact(contact);
                }

            }
            if (!b)
                Console.WriteLine("There is no such contact in your contact book");


        }


        public void CreateContact()
        {
            Contact contact = new Contact();
            string str = null;


            Console.WriteLine("Please enter the name of the contact");
            str = Console.ReadLine();
            contact.Name = str;
            str = null;

            Console.WriteLine("Please enter the last name of the contact");
            str = Console.ReadLine();
            contact.LastName = str;
            str = null;

            Console.WriteLine("Please enter the number of the contact");
            str = Console.ReadLine();
            contact.Number = str;
            str = null;

            Console.WriteLine("Please enter the physical address of the contact");
            str = Console.ReadLine();
            contact.Address = str;
            str = null;


            Console.WriteLine("Please enter the email address of the contact");
            str = Console.ReadLine();
            contact.Email = str;
            str = null;

            if (!Exists(contact))
            {
                Contacts.Add(contact);
                Console.WriteLine("The contact was succesfully created");
            }

            else
                Console.WriteLine("You already have an existing contact with such parameters");

            

        }

        public void EditContact()
        {

            string str = null;
            Console.WriteLine("Please enter the number of the contact you want to edit");
            str = Console.ReadLine();
            
            Contact contact = Contacts.Find(x => x.Number == str );

            Console.WriteLine("Please enter the name of the contact");
            str = Console.ReadLine();
            contact.Name = str;
            str = null;

            Console.WriteLine("Please enter the last name of the contact");
            str = Console.ReadLine();
            contact.LastName = str;
            str = null;

            Console.WriteLine("Please enter the number of the contact");
            str = Console.ReadLine();
            contact.Number = str;
            str = null;

            Console.WriteLine("Please enter the physical address of the contact");
            str = Console.ReadLine();
            contact.Address = str;
            str = null;


            Console.WriteLine("Please enter the email address of the contact");
            str = Console.ReadLine();
            contact.Email = str;
            str = null;

            Console.WriteLine("The contact was succesfully edited");


        }

        public void DeleteContact()
        {

            Console.WriteLine("Please type the name of the contact or the number");
            string number = Console.ReadLine();

            Contact contact = Contacts.Find(x => x.Number == number);
            if (Contacts == null)
                Console.WriteLine("Your contact list is empty");
            if (Exists(contact))
                Contacts.Remove(contact);
            else
                Console.WriteLine("There is no such contact in your contact list");
        }

        private bool Exists(Contact contact)
        {
            return Contacts.Contains(contact);
        }

        public void PrintContact(Contact contact)
        {
            if (contact != null)
            {
                Console.WriteLine("{0} {1}", contact.Name, contact.LastName);
                Console.WriteLine("Number is {0}", contact.Number);
                Console.WriteLine("Address is {0}", contact.Address);
                Console.WriteLine("Email is {0}", contact.Email);
            }
        }



    }
}
