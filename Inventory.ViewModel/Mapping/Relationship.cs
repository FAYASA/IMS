using inventory.models;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
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
        public static IEnumerable<CustomerTypeListViewModel>
            ModelToVM(this IEnumerable<CustomerType> customerType)
        {
            List<CustomerTypeListViewModel> List = new List<CustomerTypeListViewModel>();
            foreach (var ct in customerType)
            {
                List.Add(new CustomerTypeListViewModel()
                {
                    CustomerTypeId = ct.CustomerTypeId,
                    CustomerTypeName = ct.CustomerTypeName,
                    Description = ct.Description
                });
            }
            return List;
        }

        /// <summary>
        /// 
        /// Getting Customer entities from the database (ApplicationDbContext.Customers),
        /// Mapping those Customer entities to CustomerListViewModel objects using ModelToVM(),
        /// Returning them as a PaginatedList(paged data).
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>


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

        public static IEnumerable<ProductTypeListViewModel> ModelToVM (this IEnumerable<inventory.models.ProductType> productTypes)
        {
            List<ProductTypeListViewModel> List = new List<ProductTypeListViewModel>();
            foreach (var pt in productTypes)
            {
                List.Add(new ProductTypeListViewModel()
                {
                    ProductTypeId = pt.ProductTypeId,
                    ProductTypeName = pt.ProductTypeName,
                    Description = pt.Description
                });
            }
            return List;

        }
    }
}
