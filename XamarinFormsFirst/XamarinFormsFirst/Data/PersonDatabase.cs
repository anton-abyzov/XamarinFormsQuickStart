using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using XamarinFormsFirst.Model;

namespace XamarinFormsFirst.Data
{
    public class PersonDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public PersonDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetPeopleAsync()
        {
            return database.Table<Person>().ToListAsync();
        }

        public Task<Person> GetPersonAsync(int id)
        {
            return database.Table<Person>().Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {
            if (person.ID != 0)
            {
                return database.UpdateAsync(person);
            }
            return database.InsertAsync(person);
        }

        public Task<int> DeletePersonAsync(Person person)
        {
            return database.DeleteAsync(person);
        }
    }
}