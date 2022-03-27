using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Services;
using AddressBook.Interfaces;

namespace AddressBook
{
    public class ContactBook
    {
        private readonly IDbService _dbService;

        public ContactBook(IDbService dbService)
        {
            _dbService = dbService;
        }

        public void Run()
        {
            Console.WriteLine("Type help to see the available commands, or type quit to exit the program");
            string cmd;

            while (true)
            {
                cmd = Console.ReadLine();

                switch (cmd.ToLower())
                {
                    case "help":
                        PrintHelp();
                        break;
                    case "showcontacts":
                        ShowContacts();
                        break;
                    case "viewcontact":
                        ViewContact();
                        break;
                    case "createcontact":
                        CreateContact();
                        break;
                    case "editcontact":
                        EditContact();
                        break;
                    case "deletecontact":
                        DeleteContact();
                        break;
                    case "quit":
                        return;
                    default:
                        Console.WriteLine("Invalid command, try typing Help");
                        break;
                }
            }
        }

        private void ShowContacts()
        {
            List<Contact> contacts = _dbService.GetAllContacts();
            if (contacts.Count != 0)
            {
                Console.WriteLine("There are {0} contacts in your contact list, printing them below", contacts.Count);
                foreach (Contact contact in contacts)
                {
                    PrintContact(contact);
                }
            }
            else
            {
                Console.WriteLine("Your contact book is empty");
            }
        }

        private void ViewContact()
        {
            Console.WriteLine("Please type the name or the phone number of the contact");
            string search = Console.ReadLine();

            List<Contact> contacts = _dbService.FindContacts(search);

            foreach (Contact contact in contacts)
            {
                PrintContact(contact);
            }

            if (contacts.Count == 0)
            {
                Console.WriteLine("Contact not found!");
            }
        }

        private void CreateContact()
        {
            Contact contact = ReadContact();

            if (_dbService.FindContactByNumber(contact.PhoneNumber) == null)
            {
                _dbService.CreateContact(contact);
                Console.WriteLine("The contact was successfully created");
            }
            else
            {
                Console.WriteLine("You already have an existing contact with the given phone number");
            }
        }

        private void EditContact()
        {
            Console.WriteLine("Please enter the phone number of the contact you want to edit");
            string number = Console.ReadLine();

            Contact contact = _dbService.FindContactByNumber(number);

            if (contact == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            Contact editedContact = ReadContact();

            _dbService.EditContact(contact.Id, editedContact);

            Console.WriteLine("The contact was edited succesfully");
        }

        private void DeleteContact()
        {
            Console.WriteLine("Please type the phone number of the contact");

            string number = Console.ReadLine();

            Contact contact = _dbService.FindContactByNumber(number);

            if (contact != null)
            {
                _dbService.RemoveContact(contact.Id);
                Console.WriteLine("The contact was deleted successfully");
            }
            else
            {
                Console.WriteLine("Contact not found!");
            }
        }

        private Contact ReadContact()
        {
            Contact contact = new Contact();

            Console.WriteLine("Please enter contact information");
            do
            {
                Console.Write("Full Name: ");
                contact.FullName = Console.ReadLine();
            }
            while (String.IsNullOrEmpty(contact.FullName));

            do
            {
                Console.Write("Phone Number: ");
                contact.PhoneNumber = Console.ReadLine();
            }
            while (String.IsNullOrEmpty(contact.PhoneNumber));

            Console.Write("Physical address: ");
            contact.Address = Console.ReadLine();

            do
            {
                Console.Write("Email address: ");
                contact.Email = Console.ReadLine();
            }
            while (String.IsNullOrEmpty(contact.Email));

            return contact;
        }

        private void PrintContact(Contact contact)
        {
            Console.WriteLine("Contact ID {0}", contact.Id);
            Console.WriteLine(contact.FullName);
            Console.WriteLine("Number is {0}", contact.PhoneNumber);
            Console.WriteLine("Address is {0}", contact.Address);
            Console.WriteLine("Email is {0}", contact.Email);
        }

        private void PrintHelp()
        {
            Console.WriteLine("The available commands are:");
            Console.WriteLine("ShowContacts to see all your contacts");
            Console.WriteLine("CreateContact to create a new contact");
            Console.WriteLine("EditContact to edit an existing contact");
            Console.WriteLine("DeleteContact to delete an existing contact");
            Console.WriteLine("Quit to close the app");
        }
    }
}
