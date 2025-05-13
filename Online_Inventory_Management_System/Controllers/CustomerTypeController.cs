using Inventory.repository.CustomerType;
using Inventory.ViewModel.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Online_Inventory_Management_System.Controllers
{
    public class CustomerTypeController : Controller
    {
        private ICustomerTypeRepo _customerTypeRepo;

        public CustomerTypeController(ICustomerTypeRepo customerTypeRepo)
        {
            _customerTypeRepo = customerTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var customerType = await _customerTypeRepo.GetAll(pageSize, pageNumber);
            return View(customerType);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateCustomerTypeViewModel model) 
        {
            if (ModelState.IsValid)
            {
                _customerTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View(model); // Pass model back to the view in case of validation errors
        }

        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _customerTypeRepo.Delete(id);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _customerTypeRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CustomerTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}

