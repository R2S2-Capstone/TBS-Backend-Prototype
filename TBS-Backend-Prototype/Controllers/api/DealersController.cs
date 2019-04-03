using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBS_Backend_Prototype.Models;

namespace TBS_Backend_Prototype.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DealersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Dealers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dealer>>> GetDealers()
        {
            return await _context.Dealers.ToListAsync();
        }

        // GET: api/Dealers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dealer>> GetDealer(int id)
        {
            var dealer = await _context.Dealers.FindAsync(id);

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

            _context.Entry(dealer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealerExists(id))
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
            _context.Dealers.Add(dealer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDealer", new { id = dealer.Id }, dealer);
        }

        // DELETE: api/Dealers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dealer>> DeleteDealer(int id)
        {
            var dealer = await _context.Dealers.FindAsync(id);
            if (dealer == null)
            {
                return NotFound();
            }

            _context.Dealers.Remove(dealer);
            await _context.SaveChangesAsync();

            return dealer;
        }

        private bool DealerExists(int id)
        {
            return _context.Dealers.Any(e => e.Id == id);
        }
    }
}
