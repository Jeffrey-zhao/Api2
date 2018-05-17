using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Process();
            Console.Read();
        }

        private async static void Process()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost/selfhost/api/contact");
            IEnumerable<Contact> contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            Console.WriteLine("当前联系人表：");
            ListContacts(contacts);

            //add contact
            Contact contact = new Contact
            {
                Name = "王五",
                PhoneNo = "000000123312",
                EmailAddress = "wangwu@gmail.com",
            };

            await httpClient.PostAsJsonAsync<Contact>("http://localhost/selfhost/api/contact", contact);
            Console.WriteLine("添加联系人：王五");
            response = await httpClient.GetAsync("http://localhost/selfhost/api/contact");
            contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            ListContacts(contacts);

            // update contact

            response = await httpClient.GetAsync("http://localhost/selfhost/api/contact/001");
            contact = (await response.Content.ReadAsAsync<IEnumerable<Contact>>()).First();
            contact.Name = "赵六";
            contact.EmailAddress = "zhaoliu@gmail.com";
            await httpClient.PutAsJsonAsync<Contact>("http://localhost/selfhost/api/contact/001", contact);
            Console.WriteLine("update contact");
            response = await httpClient.GetAsync("http://localhost/selfhost/api/contact");
            contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            ListContacts(contacts);

            await httpClient.DeleteAsync("http://localhost/selfhost/api/contact/002");
            Console.WriteLine("delete contact");
            response = await httpClient.GetAsync("http://localhost/selfhost/api/contact");
            contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            ListContacts(contacts);
        }

        private static void ListContacts(IEnumerable<Contact> contacts)
        {
            foreach (Contact item in contacts)
            {
                Console.WriteLine("{0,-6}{1,-6}{2,-20}{3,-10}", item.Id, item.Name, item.EmailAddress, item.Address);
            }
            Console.WriteLine();
        }
    }
}
