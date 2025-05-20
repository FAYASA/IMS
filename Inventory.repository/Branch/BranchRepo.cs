using Inventory.repository.Paging;
using Inventory.ViewModel.Branch;
using Inventory.ViewModel.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.Branch
{
    public class BranchRepo : IBranchRepo
    {
        private readonly ApplicationDbContext _context;

        public BranchRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(BranchViewModel model)
        {
            var DModel = model.VMToDModel();
            _context.Branches.Add(DModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var branch = _context.Branches.Find(id);
            if (branch != null)
            {
                _context.Branches.Remove(branch);
                _context.SaveChanges();
            }
        }

        public Task<PaginatedList<BranchListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var VM = _context.Branches.ModelToVM();
            return PaginatedList<BranchListViewModel>.CreateAsync(VM, pageNumber, pageSize);
        }

        public BranchViewModel GetById(int id)
        {
            var branch = _context.Branches.Include(b => b.Currency).FirstOrDefault(b => b.BranchId == id);

            //var branch = _context.Branches.Find(id);
            if (branch == null)
            {
                return null;
            }
            return new BranchViewModel
            {
                BranchId = branch.BranchId,
                BranchName = branch.BranchName,
                Description = branch.Description,
                CurrencyId = branch.CurrencyId,
                Address = branch.Address,
                City = branch.City,
                State = branch.State,
                ZipCode = branch.ZipCode,
                Phone = branch.Phone,
                Email = branch.Email,
                ContactPerson = branch.ContactPerson,
                CurrencyName = branch.Currency.Name
            };
        }

        public List<SelectListItem> GetCurrencyForDropdown()
        {
            return _context.Currencies.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }

        public void Update(BranchViewModel model)
        {
            var branch = _context.Branches.Find(model.BranchId);
            if (branch != null)
            {
                branch.BranchName = model.BranchName;
                branch.Description = model.Description;
                branch.CurrencyId = model.CurrencyId;
                branch.Address = model.Address;
                branch.City = model.City;
                branch.State = model.State;
                branch.ZipCode = model.ZipCode;
                branch.Phone = model.Phone;
                branch.Email = model.Email;
                branch.ContactPerson = model.ContactPerson;
                _context.SaveChanges();
            }
        }
    }
}
