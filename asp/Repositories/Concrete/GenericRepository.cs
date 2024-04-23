using System.Linq.Expressions;
using asp.Repositories.Interfaces;
using asp.Data;

namespace asp.Repositories.Concrete
{

    public class GenericRepository<T>(ToDoElementsContext _context, IConfiguration _configuration) : IGenericRepository<T> where T : class
    {
        protected readonly ToDoElementsContext Context = _context;
        protected readonly IConfiguration _configuration = _configuration;

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return [.. Context.Set<T>()];
        }

        public void Remove (T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}