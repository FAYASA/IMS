﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.models
{
    public class SalesOrderLine
    {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public int ProductId { get; set; }
        public string Discription { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double DiscountPercentage { get; set; }
        public double DiscountAmount { get; set; }
        public double Subtotal { get; set; }
        public double TaxPercentage { get; set; }
        [Display(Name = "Tax Amount")]
        public double TaxAmount { get; set; }
        public double Total { get; set; }
    }
}
