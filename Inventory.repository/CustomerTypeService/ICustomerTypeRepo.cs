﻿using Inventory.repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.CustomerType
{
    public interface ICustomerTypeRepo
    {
        Task<PaginatedList<CustomerTypeListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(CreateCustomerTypeViewModel model);
        void Update(CustomerTypeViewModel model);
        void Delete(int id);
        CustomerTypeViewModel GetById(int id);

    }
}
