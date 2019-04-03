using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TBS_Backend_Prototype.Models;

namespace TBS_Backend_Prototype.Repository.Dealers
{
    public class DealerRepository : IDealerRepository
    {
        private readonly ApplicationDbContext _context;

        public DealerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Dealer dealer)
        {
            await _context.Dealers.AddAsync(dealer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DealerExistsAsync(int id)
        {
            return await _context.Dealers.AnyAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Dealer>> GetAllDealers()
        {
            return await _context.Dealers.ToListAsync();
        }

        public async Task<Dealer> GetById(int id)
        {
            return await _context.Dealers.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task Remove(int id)
        {
            _context.Dealers.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }

        public async Task Update(Dealer dealer)
        {
            await Remove(dealer.Id);
            await Add(dealer);
        }
    }
}
