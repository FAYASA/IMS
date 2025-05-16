using inventory.models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Customer
{
    public class CustomerTypeViewModel
    {

        public int CustomerTypeId { get; set; }
        public string CustomerTypeName { get; set; }
        public string Description { get; set; }

        public void VMtoModel(CustomerType model)
        {
            model.CustomerTypeId = this.CustomerTypeId;
            model.CustomerTypeName = this.CustomerTypeName;
            model.Description = this.Description;
        }

        public void ModelToVM(CustomerType model)
        {
            this.CustomerTypeId = model.CustomerTypeId;
            this.CustomerTypeName = model.CustomerTypeName;
            this.Description = model.Description;
        }

    }
}
