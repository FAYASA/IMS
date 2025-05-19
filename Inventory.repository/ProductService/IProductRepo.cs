using Inventory.repository.Paging;
using Inventory.ViewModel.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.ProductService
{
    public interface IProductRepo
    {
        Task<PaginatedList<ProductListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(ProductViewModel model);
        void Update(ProductViewModel model);
        void Delete(int id);
        ProductViewModel GetById(int id);
        List<SelectListItem> GetProductTypesForDropdown();

        List<SelectListItem> GetBranchForDropdown();

        List<SelectListItem> GetCurrencyForDropdown();
        Task<string> UploadImageAsync(IFormFile imageFile);
    }
}
