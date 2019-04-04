using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBS_Backend_Prototype.Models;
using TBS_Backend_Prototype.Repository.Vehicles;

namespace TBS_Backend_Prototype.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _repository;

        public VehiclesController(IVehicleRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _repository.GetAllVehicles();
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _repository.GetById(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.Update(vehicle);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vehicles
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            await _repository.Add(vehicle);

            return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicle>> DeleteVehicle(int id)
        {
            var vehicle = await _repository.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            await _repository.Remove(id);

            return vehicle;
        }

        public async Task<bool> VehicleExists(int id)
        {
            return await _repository.VehicleExists(id);
        }
    }
}
