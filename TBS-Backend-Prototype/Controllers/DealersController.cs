using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBS_Backend_Prototype.Models;
using TBS_Backend_Prototype.Repository.Dealers;

namespace TBS_Backend_Prototype.Controllers
{
    public class DealersController : Controller
    {
        private readonly IDealerRepository _repository;

        public DealersController(IDealerRepository repository)
        {
            _repository = repository;
        }

        // GET: Dealers
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllDealers());
        }

        // GET: Dealers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dealer = await _repository.GetById(id.Value);
            if (dealer == null)
            {
                return NotFound();
            }

            return View(dealer);
        }

        // GET: Dealers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dealers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,ComapnyPaymentEmail,ComapnyAddress,ContactFirstName,ContactLastName,ContactPhoneNumber,ContactEmail")] Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(dealer);
                return RedirectToAction(nameof(Index));
            }
            return View(dealer);
        }

        // GET: Dealers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dealer = await _repository.GetById(id.Value);
            if (dealer == null)
            {
                return NotFound();
            }
            return View(dealer);
        }

        // POST: Dealers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,ComapnyPaymentEmail,ComapnyAddress,ContactFirstName,ContactLastName,ContactPhoneNumber,ContactEmail")] Dealer dealer)
        {
            if (id != dealer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(dealer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealerExists(dealer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dealer);
        }

        // GET: Dealers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dealer = await _repository.GetById(id.Value);
            if (dealer == null)
            {
                return NotFound();
            }

            return View(dealer);
        }

        // POST: Dealers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DealerExists(int id)
        {
            var result = _repository.DealerExistsAsync(id);
            return result.Result;
        }
    }
}
