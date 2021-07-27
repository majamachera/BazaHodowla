using System.Collections.Generic;
using System.Threading.Tasks;
using BazadlaL.API.Models;

namespace BazadlaL.API.Data
{
    public interface ITreatmentsRep : IGenericRepository
    {
       
        Task<Fdog> GetFdogVaccination(int idv);
        Task<Fdog> GetFdogDeworming(int idd);
        Task<IEnumerable<VaccinationPuppy>> GetVaccinationsPuppy();
        Task<IEnumerable<VaccinationDog>> GetVaccinationsDog();
        Task<IEnumerable<DewormingPuppy>> GetDewormingsPuppy();
        Task<IEnumerable<DewormingDog>> GetDewormingsDog();
        Task<DewormingDog> GetDewormingDog(int idp);
        Task<DewormingPuppy> GetDewormingPuppy(int idp);
        Task<VaccinationDog> GetVaccinationDog(int idp);
        Task<VaccinationPuppy> GetVaccinationPuppy(int idp);
        Task<VaccinationDog> GetThisVaccinationDog(int id);
        Task<VaccinationPuppy> GetThisVaccinationPuppy(int id);
        Task<DewormingPuppy> GetThisDewormingPuppy(int id);
        Task<DewormingDog> GetThisDewormingDog(int id);
        Task<Puppy> GetPuppyVaccination(int idpv);
        Task<Puppy> GetPuppyDeworming(int idpd);
    
    }
}