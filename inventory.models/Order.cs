﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory.models
{
    internal class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public OrderType OrderType { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public decimal SubTotal { get; set; }
        public decimal itemDiscount { get; set; }
        public decimal Tax { get; set; }
        public decimal ShippingCharges { get; set; }
        public decimal Total { get; set; }
        public string PromoCode { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Discription { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

namespace inventory.models
{
    public enum OrderStatus
    {
        CheckOut,Paid,Failed,Shipped,Delivered,Returned,Complete
    }
}

namespace inventory.models
{
    public enum OrderType
    {
        PurchaseOrder,CustomerOrder
    }
}