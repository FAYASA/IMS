using Inventory.repository.Branch;
using Inventory.ViewModel.Branch;
using Microsoft.AspNetCore.Mvc;

namespace Online_Inventory_Management_System.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchRepo _branchRepo;

        public BranchController(IBranchRepo branchRepo)
        {
            _branchRepo = branchRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = 10, int pageNumber = 1)
        {
            var branches = await _branchRepo.GetAll(pageSize, pageNumber);
            return View(branches);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //ViewBag.Currency = _branchRepo.GetCurrencyForDropdown();
            var viewModel = new BranchViewModel
            {
                Currencies = _branchRepo.GetCurrencyForDropdown()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(BranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                _branchRepo.Add(model);
                return RedirectToAction("Index");
            }
            model.Currencies = _branchRepo.GetCurrencyForDropdown();
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var branch = _branchRepo.GetById(id);
            if (branch == null)
            {
                return NotFound();
            }
            branch.Currencies = _branchRepo.GetCurrencyForDropdown();
            return View(branch);
        }
        [HttpPost]
        public ActionResult Edit(BranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                _branchRepo.Update(model);
                return RedirectToAction("Index");
            }
            model.Currencies = _branchRepo.GetCurrencyForDropdown();
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            _branchRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
