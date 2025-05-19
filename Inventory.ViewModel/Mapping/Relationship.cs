using inventory.models;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Currency;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Invoice;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Mapping
{
    public static class Relationship
    {

        public static IQueryable<CustomerTypeListViewModel> ModelToVM(this IQueryable<CustomerType> CustomerType)
        {
            // •	When need to map or transform data from one type to another.
            return CustomerType.Select(ct => new CustomerTypeListViewModel
            {
                CustomerTypeId = ct.CustomerTypeId,
                CustomerTypeName = ct.CustomerTypeName,
                Description = ct.Description
            });
        }

        /// Getting Customer entities from the database (ApplicationDbContext.Customers),
        /// Mapping those Customer entities to CustomerListViewModel objects using ModelToVM(),
        /// Returning them as a PaginatedList(paged data).
        /// 


        ///// This is a method that will convert a list of Customer into a list of CustomerListViewModel.
        public static IEnumerable<CustomerListViewModel>
            ModelToVM(this IEnumerable<inventory.models.Customer> customers)
        {
            List<CustomerListViewModel> List = new List<CustomerListViewModel>();
            foreach (var ct in customers)
            {
                ///// Create a new CustomerListViewModel and fill it with
                ///// the matching fields from the Customer object,
                ///// then add it to the new list.
                List.Add(new CustomerListViewModel()
                {
                    CustomerId = ct.CustomerId,
                    CustomerName = ct.CustomerName,
                    City = ct.City,
                    State = ct.State,
                    Address = ct.Address,
                    ZipCode = ct.ZipCode,
                    Phone = ct.Phone,
                    Email = ct.Email,
                    ContactPerson = ct.ContactPerson
                });
            }
            return List;
        }

        //public static IEnumerable<BillTypeListViewModel> ModelToVM (this IEnumerable<BillType> billType)
        //{
        //    List<BillTypeListViewModel> List = new List<BillTypeListViewModel>();
        //    foreach (var bt in billType)
        //    {
        //        List.Add(new BillTypeListViewModel()
        //        {
        //            BillTypeId = bt.BillTypeId,
        //            BillTypeName = bt.BillTypeName,
        //            Description = bt.Description
        //        });
        //    }
        //    return List;

        //}

        public static IQueryable<BillTypeListViewModel> ModelToVM(this IQueryable<BillType> billType)
        {
            // •	When need to map or transform data from one type to another.
            return billType.Select(bt => new BillTypeListViewModel
            {
                BillTypeId = bt.BillTypeId,
                BillTypeName = bt.BillTypeName,
                Description = bt.Description
            });
        }


        public static IEnumerable<BillListViewModel> ModelToVM (this IEnumerable<inventory.models.Bill> bill)
        {
            List<BillListViewModel> List = new List<BillListViewModel>();
            foreach (var b in bill)
            {
                List.Add(new BillListViewModel()
                {
                    BillId = b.BillId,
                    BillName = b.BillName,
                    GoodReceiverNoteId = b.GoodReceiverNoteId,
                    VendorDoNumber = b.VendorDoNumber,
                    VendorinvoiceNumber = b.VendorinvoiceNumber,
                    BillDate = b.BillDate,
                    BillDueDate = b.BillDueDate,
                    BillTypeId = b.BillTypeId
                });
            }
            return List;

        }

        public static IQueryable<ProductTypeListViewModel> ModelToVM(this IQueryable<ProductType> ProductType)
        {
            return ProductType.Select(pt => new ProductTypeListViewModel
            {
                ProductTypeId = pt.ProductTypeId,
                ProductTypeName = pt.ProductTypeName,
                Description = pt.Description
            });
        }

        public static IQueryable<InvoiceTypeListViewModel> ModelToVM(this IQueryable<InvoiceType> invoiceType)
        {
            // •	When need to map or transform data from one type to another.
            return invoiceType.Select(it => new InvoiceTypeListViewModel
            {
                InvoiceTypeId = it.InvoiceTypeId,
                InvoiceTypeName = it.InvoiceTypeName,
                Description = it.Description
            });
        }

        public static IQueryable<CurrencyListViewModel> ModelToVM(this IQueryable<inventory.models.Currency> currency)
        {
            // •	When need to map or transform data from one type to another.
            return currency.Select(it => new CurrencyListViewModel
            {
                Id = it.Id,
                Name = it.Name,
                Code = it.Code,
                Description = it.Description
            });
        }
        public static IQueryable<ProductListViewModel> ModelToVM(this IQueryable<inventory.models.Product> product)
        {
            // •	When need to map or transform data from one type to another.
            return product.Select(it => new ProductListViewModel
            {
                ProductId = it.ProductId,
                ProductName = it.ProductName,
                ProductCode = it.ProductCode,
                Barcode = it.Barcode,
                Description = it.Description,
                ProductImage = it.ProductImage,
                MeasureUnitId = it.MeasureUnitId,
                BuyingPrice = it.BuyingPrice,
                SellingPrice = it.SellingPrice,
                BranchId = it.BranchId,
                CurrencyId = it.CurrencyId,
                ProductTypeId = it.ProductTypeId,
                ProductTypeName = it.ProductType.ProductTypeName,
                BranchName = it.Branch.BranchName,
                Currency = it.Currency.Name
            });
        }

        //public static IQueryable<ProductListViewModel> ModelToVM(this IQueryable<inventory.models.Product> product)
        //{
        //    return product.Select(it => new ProductListViewModel
        //    {
        //        ProductId = it.ProductId,
        //        ProductName = it.ProductName,
        //        ProductTypeId = it.ProductTypeId,
        //        Description = it.Description,
        //        UnitPrice = it.UnitPrice,
        //        Quantity = it.Quantity
        //    });
        //}

        //public static IQueryable<InvoiceListViewModel> ModelToVM(this IQueryable<inventory.models.Invoice> invoice)
        //{
        //    return invoice.Select(it => new InvoiceListViewModel
        //    {
        //        InvoiceId = it.InvoiceId,
        //        InvoiceName = it.InvoiceName,
        //        CustomerId = it.CustomerId,
        //        InvoiceDate = it.InvoiceDate,
        //        InvoiceDueDate = it.InvoiceDueDate,
        //        InvoiceTypeId = it.InvoiceTypeId
        //    });
        //}
    }
}
