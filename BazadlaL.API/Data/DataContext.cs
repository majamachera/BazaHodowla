using Microsoft.EntityFrameworkCore;
using BazadlaL.API.Models;


namespace BazadlaL.API.Data
{
    public class DataContext : DbContext
    {
     public DataContext(DbContextOptions<DataContext> options) : base(options){ } 
       
    public DbSet<Value> Values { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Fdog> Fdog { get; set; }
    public DbSet<Puppy> Puppy {get;set;}
    public DbSet<VaccinationDog> VaccinationDog {get; set;}
    public DbSet<VaccinationPuppy> VaccinationPuppy {get; set;}
    public DbSet<DewormingDog> DewormingDog {get; set;}
    public DbSet<DewormingPuppy> DewormingPuppy {get; set;}
    }
}