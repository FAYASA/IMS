using inventory.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Product
{
    public class CreateProductTypeViewModel
    {
        public int ProductTypeId { get; set; }
        [Required]
        public string ProductTypeName { get; set; }
        public string Description { get; set; }

        public ProductType VMToModel()
        {
            return new ProductType
            {
                ProductTypeId = this.ProductTypeId,
                ProductTypeName = this.ProductTypeName,
                Description = this.Description
            };
        }
    }
}
