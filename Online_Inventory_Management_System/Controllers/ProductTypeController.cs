using Inventory.repository.ProductTypeService;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Product;
using Microsoft.AspNetCore.Mvc;

namespace Online_Inventory_Management_System.Controllers
{
    public class ProductTypeController : Controller
    {
        private IProductTypeRepo _productTypeRepo;

        public ProductTypeController(IProductTypeRepo productTypeRepo)
        {
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var productTypes = await _productTypeRepo.GetAll(pageSize, pageNumber);
            return View(productTypes);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateProductTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View(model); // Pass model back to the view in case of validation errors
        }

        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _productTypeRepo.Delete(id);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _productTypeRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
