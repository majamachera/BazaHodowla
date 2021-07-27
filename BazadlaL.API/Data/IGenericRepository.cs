using System.Threading.Tasks;

namespace BazadlaL.API.Data
{
    public interface IGenericRepository
    {
         void Add<T>(T entity) where T: class;
         void Delate<T>(T entity) where T: class;
         Task<bool> SaveAll();
    }
}