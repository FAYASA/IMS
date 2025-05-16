using Inventory.repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.CustomerType
{
    public class CustomerTypeRepo : ICustomerTypeRepo
    {
        private ApplicationDbContext _context;

        public CustomerTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CreateCustomerTypeViewModel model)
        {
            _context.CustomerTypes.Add(model.VMToModel());
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.CustomerTypes.Where(x => x.CustomerTypeId == id).FirstOrDefault();
            if (model != null)
            {
                _context.CustomerTypes.Remove(model);
                _context.SaveChanges();
            }
        }

        public async Task<PaginatedList<CustomerTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var customerTypeList = _context.CustomerTypes;
            var vm = customerTypeList.ModelToVM().AsQueryable();
            return await PaginatedList<CustomerTypeListViewModel>.CreateAsync(vm, pageNumber, pageSize);
        }

        public CustomerTypeViewModel GetById(int id)
        {
            var model = _context.CustomerTypes.Where(x => x.CustomerTypeId == id).FirstOrDefault();
            var vm = new CustomerTypeViewModel();
            vm.ModelToVM(model);
            return vm;
        }

        public void Update(CustomerTypeViewModel model)
        {
            var data = _context.CustomerTypes
                .Where(x => x.CustomerTypeId == model.CustomerTypeId).FirstOrDefault();

            model.VMtoModel(data);
            _context.SaveChanges();
        }
    }
}
