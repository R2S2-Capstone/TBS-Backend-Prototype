using System.Collections.Generic;
using TBS_Backend_Prototype.Models;

namespace TBS_Backend_Prototype.Repository.Vehicles
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetAllVehicles();
        Vehicle GetById(int id);
        void Add(Vehicle vehicle);
        void Remove(int id);
        void Update(Vehicle vehicle);
        bool VehicleExists(int id);
    }
}
