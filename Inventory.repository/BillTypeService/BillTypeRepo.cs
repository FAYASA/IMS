using Inventory.repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.BillTypeService
{
    public class BillTypeRepo : IBillTypeRepo
    {
        private ApplicationDbContext _context;

        public BillTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<BillTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var billTypeList = _context.BillTypes;
            var vm = billTypeList.ModelToVM().AsQueryable();
            return await PaginatedList<BillTypeListViewModel>.CreateAsync(vm, pageNumber, pageSize);
        }
    }
}
