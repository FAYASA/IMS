using inventory.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Customer
{
    public class CreateCustomerTypeViewModel
    {
        public int CustomerTypeId { get; set; }
        [Required]
        public string CustomerTypeName { get; set; }
        public string Description { get; set; }

        public CustomerType VMToModel()
        {
            return new CustomerType
            {
                CustomerTypeId = this.CustomerTypeId,
                CustomerTypeName = this.CustomerTypeName,
                Description = this.Description
            };
        }
    }
}
