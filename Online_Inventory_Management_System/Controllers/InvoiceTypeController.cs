using Inventory.repository.InvoiceTypeService;
using Inventory.ViewModel.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace Online_Inventory_Management_System.Controllers
{
    public class InvoiceTypeController : Controller
    {
        private IinvoiceTypeRepo _invoiceTypeRepo;

        public InvoiceTypeController(IinvoiceTypeRepo invoiceTypeRepo)
        {
            _invoiceTypeRepo = invoiceTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var invoiceTypes = await _invoiceTypeRepo.GetAll(pageSize, pageNumber);
            return View(invoiceTypes);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateInvoiceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _invoiceTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View(model); // Pass model back to the view in case of validation errors
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _invoiceTypeRepo.Delete(id);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _invoiceTypeRepo.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(InvoiceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _invoiceTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View(model); // Pass model back to the view in case of validation errors
        }

    }
}