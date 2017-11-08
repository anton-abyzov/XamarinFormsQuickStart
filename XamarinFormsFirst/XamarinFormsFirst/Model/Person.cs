using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace XamarinFormsFirst.Model
{
    public class Person
    {
        public Person()
        {
            Image = "smile.jpg";
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public decimal Age { get; set; }
        public string Image { get; set; }

        //public static List<Person> People { get; set; } = People = new List<Person>()
        //{
        //    new Person()
        //    {
        //        Name = "Test",
        //        Phone = "3434234",
        //        Age = 23
        //    }
        //};
    }
}
