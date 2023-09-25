using MyJourney.Data.DataAccess;
using MyJourney.Models;
using System.Linq.Expressions;

namespace MyJourney.Data
{
    public interface IRepositoryBase<T>
    {
        T GetById(int id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetWithOptions(QueryOptions<T> options);
    }
}
