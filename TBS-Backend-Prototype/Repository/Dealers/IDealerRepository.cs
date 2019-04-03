using System.Collections;
using System.Collections.Generic;
using TBS_Backend_Prototype.Models;

namespace TBS_Backend_Prototype.Repository.Dealers
{
    public interface IDealerRepository
    {
        IEnumerable<Dealer> GetAllDealers();
        Dealer GetById(int id);
        void Add(Dealer dealer);
        void Remove(int id);
        void Update(Dealer dealer);
        bool DealerExists(int id);
    }
}
