﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.models
{
    public class PaymentReceive
    {
        public int Id { get; set; }
        [Display(Name ="Payment")]
        public string Name { get; set; }
        [Display(Name = "Invoice")]
        public int InvoiceId { get; set; }
        public DateTimeOffset  DateOfPayment { get; set; }
        [Display(Name = "Payment Type")]
        public int PaymentTypeId { get; set; }
        [Display(Name = "Payment Amount")]
        public double PaymentAmount { get; set; }
        [Display(Name = "Full Payment?")]
        public bool IsFullPayment { get; set; }
    }
}
