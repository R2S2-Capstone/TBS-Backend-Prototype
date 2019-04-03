using System.Collections.Generic;
using TBS_Backend_Prototype.Models;

namespace TBS_Backend_Prototype.Repository.Vehicles
{
    public class VehicleFakeRepository : IVehicleRepository
    {
        public void Add(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            throw new System.NotImplementedException();
        }

        public Vehicle GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public bool VehicleExists(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
