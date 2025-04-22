using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        [Required]
        public string WarehouseName { get; set; }

        public string Discription { get; set; }
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
    }
}
