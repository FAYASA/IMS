using Inventory.repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.BillService
{
    public class BillRepo : IBillRepo
    {

        public ApplicationDbContext _context;

        public BillRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<BillListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var bills = _context.Bills;
            var vm = bills.ModelToVM().AsQueryable();
            return await PaginatedList<BillListViewModel>.CreateAsync(vm, pageNumber, pageSize);
        }

    }
}
