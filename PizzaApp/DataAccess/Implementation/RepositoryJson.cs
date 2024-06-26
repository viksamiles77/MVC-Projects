using DataAccess.Interface;
using DomainModels;
using Newtonsoft.Json;

namespace DataAccess.Implementation
{
    public class RepositoryJson<T> : IRepository<T> where T : BaseEntity
    {
        public List<T> GetAll()
        {
            return ReadContent();
        }

        public T GetById(int id)
        {
            var items = ReadContent();
            var item = items.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Entitty with id: {id} is not found");
            }
            return item;
        }

        public void Update(T entity)
        {
            var items = ReadContent();
            var item = items.FirstOrDefault(x => x.Id == entity.Id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Entitty with id: {entity.Id} is not found");
            }

            var indexOfItem = items.IndexOf(item);
            items[indexOfItem] = entity;
            WriteContent(items);
        }

        public void Add(T entity)
        {
            var items = ReadContent();
            var nextId = items.Max(x => x.Id) + 1;

            entity.Id = nextId;

            items.Add(entity);
            WriteContent(items);
        }

        public void Delete(T entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteById(int id)
        {
            var items = ReadContent();
            var item = items.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Entitty with id: {id} is not found");
            }

            items.Remove(item);
            WriteContent(items);
        }

        public List<T> ReadContent()
        {
            string folderPath = Environment.CurrentDirectory + @"\Data\";
            string filepath = folderPath + typeof(T).Name + "s.json";
            List<T> items = new List<T>();

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(filepath))
            {
                return new List<T>();
            }

            using (var sr = new StreamReader(filepath))
            {
                var content = sr.ReadToEnd();
                JsonSerializerSettings settings = new JsonSerializerSettings();
                items = JsonConvert.DeserializeObject<List<T>>(content);
            }

            return items;
        }

        private void WriteContent(List<T> items)
        {
            string folderPath = Environment.CurrentDirectory + @"\Data\";
            string filepath = folderPath + typeof(T).Name + "s.json";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(filepath))
            {
                File.Create(filepath).Close();
            }

            using (var sw = new StreamWriter(filepath))
            {
                var content = JsonConvert.SerializeObject(items);
                sw.WriteLine(content);
            }
        }
    }
}
