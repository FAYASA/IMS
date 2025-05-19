using Inventory.repository.ProductService;
using Inventory.ViewModel.Product;
using Microsoft.AspNetCore.Mvc;

namespace Online_Inventory_Management_System.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var products = await _productRepo.GetAll(pageSize, pageNumber);
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                ProductTypes = _productRepo.GetProductTypesForDropdown(),
                Branches = _productRepo.GetBranchForDropdown(),
                Currencies = _productRepo.GetCurrencyForDropdown()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View(model); // Pass model back to the view in case of validation errors
        }

        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Delete(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _productRepo.GetById(id);

            // Populate dropdowns
            model.ProductTypes = _productRepo.GetProductTypesForDropdown();
            model.Branches = _productRepo.GetBranchForDropdown();
            model.Currencies = _productRepo.GetCurrencyForDropdown();

            return View(model);
        }

        //[HttpGet]
        //public ActionResult Edit()
        //{
        //    var viewModel = new ProductViewModel
        //    {
        //        ProductTypes = _productRepo.GetProductTypesForDropdown(),
        //        Branches = _productRepo.GetBranchForDropdown(),
        //        Currencies = _productRepo.GetCurrencyForDropdown()
        //    };
        //    return View(viewModel);
        //}

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var model = _productRepo.GetById(id);
        //    return View(model);
        //}

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View(model); // Pass model back to the view in case of validation errors
        }
    }
}
