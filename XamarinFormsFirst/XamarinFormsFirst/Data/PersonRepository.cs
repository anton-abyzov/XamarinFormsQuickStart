using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsFirst.Model;

namespace XamarinFormsFirst.Data
{
    public class PersonRepository : GenericFileRepository<Person>
    {
        public PersonRepository() : base("PersonFile.json")
        {

        }
    }
}
