using DataAccess.Interface;
using DomainModels;

namespace DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected PizzaAppDbContext _DbContext;
        public Repository(PizzaAppDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public List<T> GetAll()
        {
            return _DbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var item = _DbContext.Set<T>().Where(x => x.Id == id).FirstOrDefault();

            if (item == null)
            {
                throw new KeyNotFoundException($"Entity with id: {id} was not found");
            }
            return item;
        }

        public void Add(T entity)
        {
            _DbContext.Add(entity);
            _DbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _DbContext.Update(entity);
            _DbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _DbContext.Remove(entity);
            _DbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            Delete(item);
        }
    }
}
