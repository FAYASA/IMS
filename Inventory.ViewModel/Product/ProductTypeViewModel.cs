using inventory.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Product
{
    public class ProductTypeViewModel
    {
        public int ProductTypeId { get; set; }
        [Required]
        public string ProductTypeName { get; set; }
        public string Description { get; set; }

        public void ModelToVM(ProductType model)
        {
            this.ProductTypeId = model.ProductTypeId;
            this.ProductTypeName = model.ProductTypeName;
            this.Description = model.Description;
        }

        public void VMToModel()
        {
            new ProductType
            {
                ProductTypeId = this.ProductTypeId,
                ProductTypeName = this.ProductTypeName,
                Description = this.Description
            };
        }
    }
}
