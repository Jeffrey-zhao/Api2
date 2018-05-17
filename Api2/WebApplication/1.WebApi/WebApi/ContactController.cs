using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi
{
    public class ContactController:ApiController
    {
        static List<Contact> contacts;
        static int counter = 2;
        static ContactController()
        {
            contacts = new List<Contact>();
            contacts.Add(new Contact { Id = "001", Name = "张三",
                PhoneNo = "0512-12345678", EmailAddress = "zhangsan@gmail.com",
                Address = "江苏省南通市" });
            contacts.Add(new Contact { Id = "002", Name = "李四",
                PhoneNo = "0512-23456789", EmailAddress = "lisi@gmail.com",
                Address = "江苏省苏州市" });
        }

        public IEnumerable<Contact> Get(string id = null)
        {
            return from contact in contacts
                   where contact.Id == id || string.IsNullOrEmpty(id)
                   select contact;
        }

        public void Post(Contact contact)
        {
            counter++;
            contact.Id = counter.ToString("D3");
            contacts.Add(contact);
        }

        public void Put(Contact contact)
        {
            contacts.Remove(contacts.First(c => c.Id == contact.Id));
            contacts.Add(contact);
        }

        public void Delete(string id)
        {
            contacts.Remove(contacts.First(c => c.Id == id));
        }
    }
}
