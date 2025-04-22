using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.models
{
    public class ShipmentType
    {
        public int Id { get; set; }
        [Required]
        public string ShipmentTypeName { get; set; }
        public string Discrption { get; set; }
    }
}
