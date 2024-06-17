using DomainModels;
namespace DataAccess.Interface
{
    public interface IPizzaRepository : IRepository<Pizza>
    {
        public List<Pizza> SearchByName(string name);
    }
}
