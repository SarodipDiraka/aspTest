using System.Linq.Expressions;

namespace asp.Repositories.Interfaces
{

    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);

        List<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove (T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        void SaveChanges();
    }
}