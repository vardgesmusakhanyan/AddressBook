using AddressBook.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace AddressBook.Services
{
    class JsonDbService : IDbService
    {
        private List<Contact> _contacts;
        private string FileName { get => @".\Contacts.json";}

        public JsonDbService()
        {
            Load();
        }

        private void SaveChanges()
        {
            string json = JsonSerializer.Serialize(_contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, json);
        }

        private void Load()
        {
            if (File.Exists(FileName))
            {
                string jsonString = File.ReadAllText(FileName);
                _contacts = JsonSerializer.Deserialize<List<Contact>>(jsonString);
            }
            else
            {
                _contacts = new List<Contact>();
            }
        }


        public int CreateContact(Contact contact)
        {
            contact.Id = (_contacts.LastOrDefault()?.Id ?? 0) + 1;
            _contacts.Add(contact);
            SaveChanges();
            return contact.Id;
        }

        public void EditContact(int id, Contact contact)
        {
            contact.Id = id;
            int index = _contacts.FindIndex(x => x.Id == id);
            _contacts[index] = contact;
            SaveChanges();
        }

        public Contact FindContactByNumber(string number)
        {
            return _contacts.FirstOrDefault(x => x.PhoneNumber == number);
        }

        public List<Contact> FindContacts(string search)
        {
            search = search.ToLower();
            return _contacts.FindAll(x => x.FullName.ToLower().Contains(search) || x.PhoneNumber.Contains(search));
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
            SaveChanges();
        }
    }
}
