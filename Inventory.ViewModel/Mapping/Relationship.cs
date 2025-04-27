using inventory.models;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Mapping
{
    public static class Relationship
    {
        public static IEnumerable<CustomerTypeListViewModel> ModelToVM(this IEnumerable<CustomerType> customerType)
        {
            List<CustomerTypeListViewModel> List = new List<CustomerTypeListViewModel>();
            foreach (var ct in customerType)
            {
                List.Add(new CustomerTypeListViewModel()
                {
                    CustomerTypeId = ct.CustomerTypeId,
                    CustomerTypeName = ct.CustomerTypeName,
                    Description = ct.Description
                });
            }
            return List;
        }
    }
}
