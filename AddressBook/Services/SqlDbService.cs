using AddressBook.DbContexts;
using AddressBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    class SqlDbService : IDbService
    {
        private readonly ContactBookDbContext _dbContext;

        public SqlDbService(ContactBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateContact(Contact contact)
        {
            contact = _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return contact.Id;
        }

        public void EditContact(int id, Contact contact)
        {
            Contact oldContact = _dbContext.Contacts.FirstOrDefault(x => x.Id == id);
            oldContact.FullName = contact.FullName;
            oldContact.PhoneNumber = contact.PhoneNumber;
            oldContact.Address = contact.Address;
            oldContact.Email = contact.Email;
            _dbContext.SaveChanges();
        }

        public Contact FindContactByNumber(string number)
        {
            return _dbContext.Contacts.FirstOrDefault(x => x.PhoneNumber == number);
        }

        public List<Contact> FindContacts(string search)
        {
            search = search.ToLower();
            return _dbContext.Contacts.Where(x => x.FullName.ToLower().Contains(search) || x.PhoneNumber.Contains(search)).ToList();
        }

        public List<Contact> GetAllContacts()
        {
            return _dbContext.Contacts.ToList();
        }

        public Contact GetContact(int id)
        {
            return _dbContext.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveContact(int id)
        {
            Contact contact = _dbContext.Contacts.FirstOrDefault(x => x.Id == id);
            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
        }
    }
}
