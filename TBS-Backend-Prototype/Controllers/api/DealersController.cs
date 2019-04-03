using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBS_Backend_Prototype.Models;
using TBS_Backend_Prototype.Repository.Dealers;

namespace TBS_Backend_Prototype.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealersController : ControllerBase
    {
        private readonly IDealerRepository _repository;

        public DealersController(IDealerRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Dealers
        [HttpGet]
        public async Task<IEnumerable<Dealer>> GetDealers()
        {
            return await _repository.GetAllDealers();
        }

        // GET: api/Dealers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dealer>> GetDealer(int id)
        {
            var dealer = await _repository.GetById(id);

            if (dealer == null)
            {
                return NotFound();
            }

            return dealer;
        }

        // PUT: api/Dealers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDealer(int id, Dealer dealer)
        {
            if (id != dealer.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.Update(dealer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DealerExistsAsync(id))
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

        // POST: api/Dealers
        [HttpPost]
        public async Task<ActionResult<Dealer>> PostDealer(Dealer dealer)
        {
            await _repository.Add(dealer);

            return CreatedAtAction("GetDealer", new { id = dealer.Id }, dealer);
        }

        // DELETE: api/Dealers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dealer>> DeleteDealer(int id)
        {
            var dealer = await _repository.GetById(id);
            if (dealer == null)
            {
                return NotFound();
            }

            await _repository.Remove(id);

            return dealer;
        }

        private async Task<bool> DealerExistsAsync(int id)
        {
            return await _repository.DealerExistsAsync(id);
        }
    }
}
