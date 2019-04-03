using System.Collections.Generic;
using System.Threading.Tasks;
using TBS_Backend_Prototype.Models;

namespace TBS_Backend_Prototype.Repository.Vehicles
{
    public class VehicleFakeRepository : IVehicleRepository
    {
        public List<Vehicle> Vehicles { get; set; }

        public VehicleFakeRepository()
        {
            Vehicles = new List<Vehicle>()
            {
                new Vehicle() { Make = "Ford", Model = "Escape", Year = 2019 },
                new Vehicle() { Make = "Ford", Model = "Mustang", Year = 1975 },
                new Vehicle() { Make = "Tesla", Model = "Model 3", Year = 2019 },
            };
        }

        public Task Add(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return await Task.FromResult(Vehicles);
        }

        public async Task<Vehicle> GetById(int id)
        {
            return await Task.FromResult(Vehicles.Find(d => d.Id == id));
        }

        public async Task Remove(int id)
        {
            Vehicles.Remove(await GetById(id));
        }

        public async Task Update(Vehicle vehicle)
        {
            await Remove(vehicle.Id);
            await Add(vehicle);
        }

        public async Task<bool> VehicleExists(int id)
        {
            return Vehicles.Contains(await GetById(id));
        }
    }
}
