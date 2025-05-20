using Inventory.repository.Paging;
using Inventory.ViewModel.Branch;
using Inventory.ViewModel.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.Branch
{
    public interface IBranchRepo
    {
        Task<PaginatedList<BranchListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(BranchViewModel model);
        void Update(BranchViewModel model);
        void Delete(int id);
        BranchViewModel GetById(int id);

        List<SelectListItem> GetCurrencyForDropdown();
    }
}
