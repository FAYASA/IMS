using Inventory.repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.ProductTypeService
{
    public class ProductTypeRepo : IProductTypeRepo
    {
        public ApplicationDbContext _context;

        public ProductTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        async Task<PaginatedList<ProductTypeListViewModel>> IProductTypeRepo.GetAll(int pageSize, int pageNumber)
        {
            var ProductType = _context.productTypes;
            var vm = ProductType.ModelToVM().AsQueryable();
            return await PaginatedList<ProductTypeListViewModel>.CreateAsync(vm, pageNumber, pageSize);
        }
    }
}
