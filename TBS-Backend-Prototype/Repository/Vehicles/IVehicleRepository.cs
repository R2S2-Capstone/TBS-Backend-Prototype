using System.Collections.Generic;
using System.Threading.Tasks;
using TBS_Backend_Prototype.Models;

namespace TBS_Backend_Prototype.Repository.Vehicles
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehicles();
        Task<Vehicle> GetById(int id);
        Task Add(Vehicle vehicle);
        Task Remove(int id);
        Task Update(Vehicle vehicle);
        Task<bool> VehicleExists(int id);
    }
}
