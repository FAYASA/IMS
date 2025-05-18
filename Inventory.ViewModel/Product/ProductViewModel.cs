using inventory.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.ViewModel.Product
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        [Display(Name = "Measure Unit")]
        public int MeasureUnitId { get; set; }
        public double BuyingPrice { get; set; }
        public double SellingPrice { get; set; }
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }

        [Display(Name = "Product Type")]
        [Required]
        public int ProductTypeId { get; set; }

        /// to show the dropdown list in the view
        public List<SelectListItem> ProductTypes { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Currencies { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Branches { get; set; } = new List<SelectListItem>();
    }
}
