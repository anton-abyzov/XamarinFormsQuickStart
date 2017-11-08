using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsFirst.Data
{
    public class GenericFileRepository<T> where T: IEntity
    {
        private string _fileName;
        public GenericFileRepository(string filename)
        {
            this._fileName = filename;
        }

        public IEnumerable<T> GetAll()
        {
            return LoadEntities();
        }

        public T Get(int id)
        {
            var items = LoadEntities();
            return items.FirstOrDefault(i => i.ID == id);
        }

        private IEnumerable<T> LoadEntities()
        {
            var savedJson = DependencyService.Get<IFile>().LoadText(_fileName);
            var deserializedTrayItems = JsonConvert.DeserializeObject<IEnumerable<T>>(savedJson);
            return deserializedTrayItems;
        }

        public void Save(IEnumerable<T> entities){
            StoreEntities(entities);
        }

        public void Save(T entity)
        {
            List<T> items;
            if (DependencyService.Get<IFile>().FileExists(_fileName))
            {
                items = LoadEntities().ToList();
                var item = items.FirstOrDefault(i => i.ID == entity.ID);
                if (item != null)
                {
                    items.Remove(item);
                }
            }
            else
            {
                items = new List<T>();
            }
            items.Add(entity);
            StoreEntities(items);
        }

        private void StoreEntities(IEnumerable<T> entities)
        {
            var serializedEntities = JsonConvert.SerializeObject(entities);
            DependencyService.Get<IFile>().SaveText(_fileName, serializedEntities);
        }

        public void Delete(int id)
        {
            var items = LoadEntities().ToList();
            var item = items.FirstOrDefault(i => i.ID == id);
            if (item != null)
            {
                items.Remove(item);
            }
            StoreEntities(items);
        }
    }
    
}
