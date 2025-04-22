using inventory.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
            base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillType> BillTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }
        public DbSet<NumberSequence> NumberSequences { get; set; }
        public DbSet<PaymentReceive> PaymentReceives { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<PaymentVoucher> PaymentVouchers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        public DbSet<PurchaseOrder> purchaseOrders { get; set; }
        public DbSet<PurchaseOrderLine> purchaseOrderLines { get; set; }
        public DbSet<PurchaseType> purchaseTypes { get; set; }
        public DbSet<ReceivedNote> receivedNotes { get; set; }
        public DbSet<SalesOrder> salesOrders { get; set; }
        public DbSet<SalesOrderLine> salesOrderLines { get; set; }
        public DbSet<SalesType> salesTypes { get; set; }
        public DbSet<Shipment> shipments { get; set; }
        public DbSet<ShipmentType> shipmentTypes { get; set; }
        public DbSet<UserProfile> userProfiles { get; set; }
        public DbSet<Vendor> vendors { get; set; }
        public DbSet<VendorType> vendorTypes { get; set; }
        public DbSet<Warehouse> warehouses { get; set; }


    }
}
