﻿using Inventory.repository.BillTypeService;
using Inventory.ViewModel.Bill;
using Microsoft.AspNetCore.Mvc;

namespace Online_Inventory_Management_System.Controllers
{
    public class BillTypesController : Controller
    {
        private IBillTypeRepo _billTypeRepo;

        public BillTypesController(IBillTypeRepo billTypeRepo)
        {
            _billTypeRepo = billTypeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize=10, int pageNumber=1)
        {
            var billTypes = await _billTypeRepo.GetAll(pageSize, pageNumber);
            return View(billTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (CreateBillTypeViewModel model)
        {
            if(ModelState.IsValid)
            {
                _billTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _billTypeRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BillTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _billTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _billTypeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
