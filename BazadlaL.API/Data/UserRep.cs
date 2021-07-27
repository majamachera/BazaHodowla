
using System.Collections.Generic;
using System.Threading.Tasks;
using BazadlaL.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BazadlaL.API.Data
{
    public class UserRep : GenericRep, IUserRep
    {
        private readonly DataContext _context;
        public UserRep(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Fdog>> GetFdogs()
        {
            
           var fdog = await _context.Fdog.Include(x => x.Puppies).ToListAsync();
            return fdog;
          
           
         
        }
       public async Task<IEnumerable<Puppy>> GetPuppies()
        {
        var pup = await _context.Puppy.ToListAsync();
        return pup;
      
        }
         public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(x => x.Fdogs).FirstOrDefaultAsync(p => p.Id == id);
            return user;
        }
         public async Task<Fdog> GetFdog(int idp)
        {
            var fdog = await _context.Fdog.Include(x => x.Puppies).FirstOrDefaultAsync(p => p.Id == idp);
            return fdog;
        }
        
       
        public async Task<Puppy> GetPuppy(int idp)
        {
            var pup = await _context.Puppy.FirstOrDefaultAsync(p => p.Id == idp);
            return pup;
        }
        
        public async Task<Fdog> GetThisFdog(int id)
        {
           var fdog = await _context.Fdog.FirstOrDefaultAsync(p => p.Id == id);
            return fdog;
        
        }
        
        public async Task<Puppy> GetThisPuppy(int id)
        {
           var fdog = await _context.Puppy.FirstOrDefaultAsync(p => p.Id == id);
            return fdog;
        
        }
        
    }    
}