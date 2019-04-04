using System.Collections.Generic;
using System.Threading.Tasks;
using TBS_Backend_Prototype.Models;

namespace TBS_Backend_Prototype.Repository.Dealers
{
    public class DealerFakeRepository : IDealerRepository
    {
        public List<Dealer> Dealers { get; set; }
        public DealerFakeRepository()
        {
            Dealers = new List<Dealer>()
            {
                new Dealer() { Id = 1, CompanyName = "TBS 1", ContactFirstName = "TBS", ContactLastName = "One", ContactEmail = "tbs@one.com", ContactPhoneNumber = "123-456-789", CompanyPaymentEmail = "payment@test.com", CompanyAddress = "123 Test Drive" },
                new Dealer() { Id = 2, CompanyName = "TBS 2", ContactFirstName = "TBS", ContactLastName = "Two", ContactEmail = "tbs@two.com", ContactPhoneNumber = "123-456-789", CompanyPaymentEmail = "payment@test.com", CompanyAddress = "123 Test Drive" },
                new Dealer() { Id = 3, CompanyName = "TBS 3", ContactFirstName = "TBS", ContactLastName = "Three", ContactEmail = "tbs@three.com", ContactPhoneNumber = "123-456-789", CompanyPaymentEmail = "payment@test.com", CompanyAddress = "123 Test Drive" },
                new Dealer() { Id = 4, CompanyName = "TBS 4", ContactFirstName = "TBS", ContactLastName = "Four", ContactEmail = "tbs@four.com", ContactPhoneNumber = "123-456-789", CompanyPaymentEmail = "payment@test.com", CompanyAddress = "123 Test Drive" },
            };
        }

        public Task Add(Dealer dealer)
        {
            Dealers.Add(dealer);
            return Task.CompletedTask;
        }

        public async Task<bool> DealerExistsAsync(int id)
        {
            return Dealers.Contains(await GetById(id));
        }

        public async Task<IEnumerable<Dealer>> GetAllDealers()
        {
            return await Task.FromResult(Dealers);
        }

        public async Task<Dealer> GetById(int id)
        {
            return await Task.FromResult(Dealers.Find(d => d.Id == id));
        }

        public async Task Remove(int id)
        {
            Dealers.Remove(await GetById(id));
        }

        public async Task Update(Dealer dealer)
        {
            await Remove(dealer.Id);
            await Add(dealer);
        }
    }
}
