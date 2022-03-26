using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Interfaces
{
    public interface IDbService
    {
        int CreateContact(Contact contact);
        void RemoveContact(int id);
        void EditContact(int id, Contact contact);
        Contact GetContact(int id);
        List<Contact> GetAllContacts();
        List<Contact> FindContacts(string search);
        Contact FindContactByNumber(string number);
    }
}
