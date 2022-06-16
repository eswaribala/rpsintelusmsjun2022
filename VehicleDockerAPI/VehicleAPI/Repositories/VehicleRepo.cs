using Microsoft.EntityFrameworkCore;
using VehicleAPI.Contexts;
using VehicleAPI.Models;

namespace VehicleAPI.Repositories
{
    public class VehicleRepo : IVehicleRepo
    {
        private readonly InsuranceContext _db;

        //DI
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

        public async Task<bool> DeleteVehicle(long EngineNo)
        {
            var result = await this._db.Vehicles.FirstOrDefaultAsync(v => v.EngineNo
            == EngineNo);
            if (result != null)
            {
                this._db.Vehicles.Remove(result);
                await this._db.SaveChangesAsync();
            }
          result= await this._db.Vehicles.FirstOrDefaultAsync(v => v.EngineNo
           == EngineNo);
            if (result == null)
                return true;
            else
                return false;

        }

        public async Task<Vehicle> GetVehicleById(long EngineNo)
        {
           var result= await this._db.Vehicles.FirstOrDefaultAsync(v => v.EngineNo == EngineNo);
            if (result == null)
                return null;
            else
                return result;
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await this._db.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> UpdateVehicle(Vehicle Vehicle)
        {
            var result = await this._db.Vehicles.FirstOrDefaultAsync(v => v.EngineNo 
            == Vehicle.EngineNo);

            if (result != null)
            {
                result.ChassisNo = Vehicle.ChassisNo;
                await this._db.SaveChangesAsync();
                return result;
            }
            else
                return null;
        }
    }
}
