using Microsoft.EntityFrameworkCore;
using VehicleAPI.Models;

namespace VehicleAPI.Contexts
{
    public class InsuranceContext:DbContext
    {

        public InsuranceContext(DbContextOptions<InsuranceContext> options) 
            : base(options){

            this.Database.EnsureCreated();
        }

        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
