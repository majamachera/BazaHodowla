using AutoMapper;
using BazadlaL.API.Dtos;
using BazadlaL.API.Models;
namespace BazadlaL.API.helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Puppy, PuppyDto>();
            CreateMap<Fdog, FdogDto>();
            CreateMap<Fdog, FdogforAddDto>();
            CreateMap<Fdog,FdogForReturn>();
            CreateMap<Puppy, PuppyForAddDto>();
            CreateMap<Puppy,PuppyForReturnDto>();
            CreateMap<VaccinationDog, VaccinationDogDto>();
            CreateMap<VaccinationPuppy, VaccinationPuppyDto>();
            CreateMap<DewormingDog, DewormingDogDto>();
            CreateMap<DewormingPuppy, DewormingPuppyDto>();
            CreateMap<VaccinationDog, VaccinationDogForAddDto>();
            CreateMap<VaccinationPuppy, VaccinationPuppyForAddDto>();
            CreateMap<DewormingDog, DewormingDogForAddDto>();
            CreateMap<DewormingPuppy, DewormingPuppyForAddDto>();
            CreateMap<FdogforUpdateDto, Fdog>();
            CreateMap<PuppyforUpdateDto, Puppy>();
        }

    }
}