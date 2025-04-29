using inventory.models;
using Inventory.repository.Paging;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Inventory.repository.CustomerService
{
    /// <summary>
    /// 1. Connect to the database.
    /// 2. Fetch all customers from database.
    /// 3. Convert them into a clean ViewModel(only safe fields).
    /// 4. Split them into pages(example: page 1 → customers 1–10, page 2 → customers 11–20).
    /// 5. Return the page you asked for.
    /// </summary>
    public class CustomerRepo : ICustomerRepo
    {
        private ApplicationDbContext _context;

        public CustomerRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        ///////// This is a method to get customers from the database, but paginated (only a few per page).
        ///////// It returns a PaginatedList<CustomerListViewModel>.
        public async Task<PaginatedList<CustomerListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            //// Fetch all customers from the database table. (But not yet send them anywhere.)
            var customereList = _context.Customers;

            /// Convert all Customer entities into CustomerListViewModel
            /// (smaller, safer version) and make it IQueryable (so EF Core can work with it).
            var vm = customereList.ModelToVM().AsQueryable();

            ///// Use your PaginatedList helper class to only return
            ///// a small chunk of customers (for example: page 1, 10 customers).
            return await PaginatedList<CustomerListViewModel>.CreateAsync(vm, pageNumber, pageSize);
        }
    }
}
