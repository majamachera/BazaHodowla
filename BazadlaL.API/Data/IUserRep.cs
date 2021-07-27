using System.Collections.Generic;
using System.Threading.Tasks;
using BazadlaL.API.Models;

namespace BazadlaL.API.Data
{
    public interface IUserRep : IGenericRepository
    {
        Task<IEnumerable<Fdog>> GetFdogs();
        Task<IEnumerable<Puppy>> GetPuppies();
        Task<User> GetUser(int id);
        Task<Fdog> GetFdog(int idp);
        Task<Puppy> GetPuppy(int idp);
        Task<Fdog> GetThisFdog(int id);
        Task<Puppy> GetThisPuppy(int id);
      
    }
}