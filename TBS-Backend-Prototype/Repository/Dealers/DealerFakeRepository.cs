using System;
using System.Collections.Generic;
using TBS_Backend_Prototype.Models;

namespace TBS_Backend_Prototype.Repository.Dealers
{
    public class DealerFakeRepository : IDealerRepository
    {
        public void Add(Dealer dealer)
        {
            throw new NotImplementedException();
        }

        public bool DealerExists(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dealer> GetAllDealers()
        {
            throw new NotImplementedException();
        }

        public Dealer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Dealer dealer)
        {
            throw new NotImplementedException();
        }
    }
}
