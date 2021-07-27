using System.Threading.Tasks;

namespace BazadlaL.API.Data
{
    public class GenericRep : IGenericRepository
    {
        private readonly DataContext _context;
        public GenericRep(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
           _context.Add(entity);
        }

        public void Delate<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
           return await _context.SaveChangesAsync() > 0;
        
        }
    }
}