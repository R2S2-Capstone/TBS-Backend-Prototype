using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TBS_Backend_Prototype.Models;

namespace TBS_Backend_Prototype.Repository.Dealers
{
    public interface IDealerRepository
    {
        Task<IEnumerable<Dealer>> GetAllDealers();
        Task<Dealer> GetById(int id);
        Task Add(Dealer dealer);
        Task Remove(int id);
        Task Update(Dealer dealer);
        Task<bool> DealerExistsAsync(int id);
    }
}
