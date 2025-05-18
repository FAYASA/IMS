using inventory.models;
using Inventory.repository.Paging;
using Inventory.ViewModel.Invoice;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.InvoiceTypeService
{
    public class InvoiceTypeRepo : IinvoiceTypeRepo
    {
        private ApplicationDbContext _context;

        public InvoiceTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateInvoiceTypeViewModel model)
        {
            var data = new InvoiceType()
            {
                InvoiceTypeId = model.InvoiceTypeId,
                InvoiceTypeName = model.InvoiceTypeName,
                Description = model.Description
            };
            _context.InvoiceTypes.Add(data);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.InvoiceTypes.Where(x => x.InvoiceTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.InvoiceTypes.Remove(model);
                _context.SaveChanges();
            }
        }

        public Task<PaginatedList<InvoiceTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var invoiceTypeList = _context.InvoiceTypes;
            var vm = invoiceTypeList.ModelToVM().AsQueryable();
            return PaginatedList<InvoiceTypeListViewModel>.CreateAsync(vm, pageNumber, pageSize);
        }

        public InvoiceTypeViewModel GetById(int id)
        {
            var model = _context.InvoiceTypes.Where(x => x.InvoiceTypeId == id).FirstOrDefault();
            var vm = new InvoiceTypeViewModel
            {
                InvoiceTypeId = model.InvoiceTypeId,
                InvoiceTypeName = model.InvoiceTypeName,
                Description = model.Description
            };
            return vm;
        }

        public void Update(InvoiceTypeViewModel model)
        {
            var data = _context.InvoiceTypes
                .Where(x => x.InvoiceTypeId == model.InvoiceTypeId).FirstOrDefault();
            data.InvoiceTypeName = model.InvoiceTypeName;
            data.Description = model.Description;
            _context.SaveChanges();
        }
    }
}
