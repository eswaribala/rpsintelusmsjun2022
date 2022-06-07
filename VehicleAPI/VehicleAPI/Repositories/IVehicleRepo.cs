using VehicleAPI.Models;

namespace VehicleAPI.Repositories
{
    //CRUD operations
    public interface IVehicleRepo
    {
       Task<Vehicle> AddVehicle(Vehicle Vehicle);
       Task<bool> DeleteVehicle(Vehicle Vehicle);

        Task<Vehicle> GetVehicleById(long EngineNo);
        IEnumerable<Task<Vehicle>> GetVehicles();

        Task<Vehicle> UpdateVehicle(Vehicle Vehicle);
            

    }
}
