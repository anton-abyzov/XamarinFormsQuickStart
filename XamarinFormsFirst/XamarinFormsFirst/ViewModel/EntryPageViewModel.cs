using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsFirst.Model;

namespace XamarinFormsFirst.ViewModel
{
    class EntryPageViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Age { get; set; }
        public void AddToPeople()
        {
            var person = new Person();
            person.Name = FirstName;
            person.Phone = PhoneNumber;
            person.Age = Age;
            //Person.People.Add(person);
            //App.Database.SavePersonAsync(person);

        }
    }
}
