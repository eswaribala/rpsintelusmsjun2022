using VehicleAPI.Contexts;
using VehicleAPI.Models;

namespace VehicleAPI.Repositories
{
    public class VehicleRepo : IVehicleRepo
    {
        private readonly InsuranceContext _db;

        public VehicleRepo(InsuranceContext db)
        {
            this._db = db;
        }
        public async Task<Vehicle> AddVehicle(Vehicle Vehicle)
        {
           var result= await this._db.Vehicles.AddAsync(Vehicle);

            await this._db.SaveChangesAsync();

            return result.Entity;

        }

        public Task<bool> DeleteVehicle(Vehicle Vehicle)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> GetVehicleById(long EngineNo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vehicle>> GetVehicles()
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> UpdateVehicle(Vehicle Vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
