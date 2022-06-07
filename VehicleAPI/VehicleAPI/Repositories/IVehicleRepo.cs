using VehicleAPI.Models;

namespace VehicleAPI.Repositories
{
    //CRUD operations
    public interface IVehicleRepo
    {
       Task<Vehicle> AddVehicle(Vehicle Vehicle);
       Task<bool> DeleteVehicle(long EngineNo);

        Task<Vehicle> GetVehicleById(long EngineNo);
        Task<IEnumerable<Vehicle>> GetVehicles();

        Task<Vehicle> UpdateVehicle(Vehicle Vehicle);
            

    }
}
