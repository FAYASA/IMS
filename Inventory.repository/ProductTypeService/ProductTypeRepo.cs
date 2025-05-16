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
        private ApplicationDbContext _context;

        public ProductTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateProductTypeViewModel model)
        {
            var vm = model.VMToModel();
            _context.productTypes.Add(vm);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.productTypes.Where(x => x.ProductTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.productTypes.Remove(model);
                _context.SaveChanges();
            }
        }

        public async Task<PaginatedList<ProductTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        
        {
            var ProductTypeList = _context.productTypes;
            var vm = ProductTypeList.ModelToVM().AsQueryable();
            return await PaginatedList<ProductTypeListViewModel>.CreateAsync(vm, pageNumber, pageSize);
        }

        public ProductTypeViewModel GetById(int id)
        {
            var model = _context.productTypes.Where(x => x.ProductTypeId == id).FirstOrDefault();
            var vm = new ProductTypeViewModel();
            vm.ModelToVM(model);
            return vm;
        }

        public void Update(ProductTypeViewModel model)
        {
            var data = _context.productTypes
                .Where(x => x.ProductTypeId == model.ProductTypeId).FirstOrDefault();
            if (data != null)
            {
                model.VMToModel();
            }
            _context.SaveChanges();
        }
    }
}
