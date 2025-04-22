using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.models
{
    public class Bill
    {
        public int BillId { get; set; }
        [Display (Name = "*Bill / Invoce number")]
        public string BillName { get; set; }
        [Display(Name ="GRN")]
        public int GoodReceiverNoteId { get; set; }
        [Display(Name = "Vendor Delivery Order")]
        public string VendorDoNumber { get; set; }
        [Display(Name = "Vendor Bill / Invoice")]
        public string VendorinvoiceNumber { get; set; }
        [Display(Name = "Bill Date")]
        public DateTimeOffset BillDate { get; set; }
        [Display(Name = "Bill Due Date")]
        public DateTimeOffset BillDueDate { get; set; }
        [Display(Name = "Bill Type")]
        public int BillTypeId { get; set; }
    }
}
