using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppSql
{
    public class Contact
    {
        String id;               
        String name = null;
        String organization = null;
        String email = null;
        String phone = null;
        String phone2 = null;
        String type = null;

        public Contact(string id)
        {
            this.id = id;
        }

        public Contact(string name, string organization, string email, string phone, string phone2, string type)
        {
            this.name = name;
            this.organization = organization;
            this.email = email;
            this.phone = phone;
            this.phone2 = phone2;
            this.type = type;
        }


        public Contact(string id, string name, string organization, string email, string phone, string phone2, string type)
        {
            this.id = id;
            this.name = name;
            this.organization = organization;
            this.email = email;
            this.phone = phone;
            this.phone2 = phone2;
            this.type = type;
        }

        public bool CheckNullOrEmpty()
        {

            return (
                !String.IsNullOrEmpty(id) ||
                !String.IsNullOrEmpty(name) ||
                !String.IsNullOrEmpty(organization) ||
                !String.IsNullOrEmpty(email) ||
                !String.IsNullOrEmpty(phone) ||
                !String.IsNullOrEmpty(phone2) ||
                !String.IsNullOrEmpty(type)
                );
        }

        public string Name { get => name; set => name = value; }
        public string Organization { get => organization; set => organization = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Phone2 { get => phone2; set => phone2 = value; }
        public string Type { get => type; set => type = value; }
        public string Id { get => id; set => id = value; }
    }


}
