using AddressBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    class InMemoryDbService : IDbService
    {
        private readonly List<Contact> _contacts = new List<Contact>();

        public int CreateContact(Contact contact)
        {            
            contact.Id = (_contacts.LastOrDefault()?.Id ?? 0) + 1;
            _contacts.Add(contact);
            return contact.Id;
        }

        public void EditContact(int id, Contact contact)
        {
            contact.Id = id;
            int index = _contacts.FindIndex(x => x.Id == id);
            _contacts[index] = contact;
        }

        public Contact FindContactByNumber(string number)
        {
            return _contacts.FirstOrDefault(x => x.Number == number);
        }

        public List<Contact> FindContacts(string search)
        {
            search = search.ToLower();
            return _contacts.FindAll(x => x.FirstName.ToLower().Contains(search) || x.Number.Contains(search));
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact GetContact(int id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveContact(int id)
        {
            int index = _contacts.FindIndex(x => x.Id == id);
            _contacts.RemoveAt(index);
        }
    }
}
