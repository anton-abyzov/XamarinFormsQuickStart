using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsFirst.Model
{
    class Person
    {
        public Person()
        {
            Image = "smile.jpg";
        }
        public string Name { get; set; }
        public decimal Age { get; set; }
        public string Image { get; set; }
    }
}
