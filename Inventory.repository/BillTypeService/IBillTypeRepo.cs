using Inventory.repository.Paging;
using Inventory.ViewModel.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.BillTypeService
{
    public interface IBillTypeRepo
    {
        Task<PaginatedList<BillTypeListViewModel>> GetAll(int pageSize, int pageNumber);

        void Add(CreateBillTypeViewModel model);
        void Update(BillTypeViewModel model);
        void Delete(int id);
        BillTypeViewModel GetById(int id);
    }
}
