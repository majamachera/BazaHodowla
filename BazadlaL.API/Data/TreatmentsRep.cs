
using System.Collections.Generic;
using System.Threading.Tasks;
using BazadlaL.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BazadlaL.API.Data
{
    public class TreatmentsRep : GenericRep, ITreatmentsRep
    {
        private readonly DataContext _context;
        public TreatmentsRep(DataContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<Fdog> GetFdogVaccination(int idv)
        {
            var fdog = await _context.Fdog.Include(x => x.VaccinationDog).FirstOrDefaultAsync(p => p.Id == idv);
            return fdog;
        }
        public async Task<Fdog> GetFdogDeworming(int idd)
        {
            var fdog = await _context.Fdog.Include(x => x.DewormingDog).FirstOrDefaultAsync(p => p.Id == idd);
            return fdog;
        }
       
       
        public async Task<Puppy> GetPuppyVaccination(int idpv)
        {
            var pup = await _context.Puppy.Include(x => x.VaccinationPuppy).FirstOrDefaultAsync(p => p.Id == idpv);
            return pup;
        }
        public async Task<Puppy> GetPuppyDeworming(int idpd)
        {
            var pup = await _context.Puppy.Include(x => x.DewormingPuppy).FirstOrDefaultAsync(p => p.Id == idpd);
            return pup;
        }
       
        public async Task<DewormingDog> GetDewormingDog(int idp)
        {
            var szczep = await _context.DewormingDog.FirstOrDefaultAsync(p => p.Id == idp);
            return szczep;
        }
        public async Task<DewormingPuppy> GetDewormingPuppy(int idp)
        {
            var odrob = await _context.DewormingPuppy.FirstOrDefaultAsync(p => p.Id == idp);
            return odrob;
        }
         public async Task<VaccinationDog> GetVaccinationDog(int idp)
        {
            var vac = await _context.VaccinationDog.FirstOrDefaultAsync(p => p.Id == idp);
            return vac;
        }
        public async Task<VaccinationPuppy> GetVaccinationPuppy(int idp)
        {
            var vac = await _context.VaccinationPuppy.FirstOrDefaultAsync(p => p.Id == idp);
            return vac;
        }

        public async Task<IEnumerable<VaccinationPuppy>> GetVaccinationsPuppy()
        {
            
           var vac = await _context.VaccinationPuppy.ToListAsync();
            return vac;
        }
        public async Task<IEnumerable<VaccinationDog>> GetVaccinationsDog()
        {
            
           var vac = await _context.VaccinationDog.ToListAsync();
            return vac;
        }
        public async Task<IEnumerable<DewormingPuppy>> GetDewormingsPuppy()
        {
            
           var odrob = await _context.DewormingPuppy.ToListAsync();
            return odrob;
        }
         public async  Task<IEnumerable<DewormingDog>> GetDewormingsDog()
        {
            
           var odrob = await _context.DewormingDog.ToListAsync();
            return odrob;
        }
       
        public async  Task<VaccinationDog> GetThisVaccinationDog(int id)
        {
           var vac = await _context.VaccinationDog.FirstOrDefaultAsync(p => p.Id == id);
            return vac;
        
        }
       public async Task<VaccinationPuppy> GetThisVaccinationPuppy(int id)
        {
           var vac = await _context.VaccinationPuppy.FirstOrDefaultAsync(p => p.Id == id);
            return vac;
        
        }
        public async Task<DewormingPuppy> GetThisDewormingPuppy(int id)
        {
           var szczep = await _context.DewormingPuppy.FirstOrDefaultAsync(p => p.Id == id);
            return szczep;
        
        }
        public async Task<DewormingDog> GetThisDewormingDog(int id)
        {
           var odrob = await _context.DewormingDog.FirstOrDefaultAsync(p => p.Id == id);
            return odrob;
        
        }
    }    
}