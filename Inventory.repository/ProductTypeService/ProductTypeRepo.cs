﻿using Inventory.repository.Paging;
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

       public async Task<PaginatedList<ProductTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        
        {
            var ProductTypeList = _context.productTypes;
            var vm = ProductTypeList.ModelToVM().AsQueryable();
            return await PaginatedList<ProductTypeListViewModel>.CreateAsync(vm, pageNumber, pageSize);
        }
    }
}
