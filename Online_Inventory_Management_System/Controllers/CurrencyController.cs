using Inventory.repository.Currency;
using Inventory.ViewModel.Currency;
using Microsoft.AspNetCore.Mvc;

namespace Online_Inventory_Management_System.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICurrencyRepo _currencyRepo;

        public CurrencyController(ICurrencyRepo currencyRepo)
        {
            _currencyRepo = currencyRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var currencies = await _currencyRepo.GetAll(pageSize, pageNumber);
            return View(currencies);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CurrencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                _currencyRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var currency = _currencyRepo.GetById(id);
            if (currency == null)
            {
                return NotFound();
            }
            return View(currency);
        }
        [HttpPost]
        public ActionResult Edit(CurrencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                _currencyRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        
        public ActionResult Delete(int id)
        {
            _currencyRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
