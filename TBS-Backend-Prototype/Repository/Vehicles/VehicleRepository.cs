using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TBS_Backend_Prototype.Models;

namespace TBS_Backend_Prototype.Repository.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetById(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task Remove(int id)
        {
            _context.Vehicles.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }

        public  async Task Update(Vehicle vehicle)
        {
            await Remove(vehicle.Id);
            await Add(vehicle);
        }

        public async Task<bool> VehicleExists(int id)
        {
            return await _context.Vehicles.AnyAsync(v => v.Id == id);
        }
    }
}
