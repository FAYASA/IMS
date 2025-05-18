using Inventory.repository.Paging;
using Inventory.ViewModel.Invoice;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.InvoiceTypeService
{
    public interface IinvoiceTypeRepo
    {
        Task<PaginatedList<InvoiceTypeListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(CreateInvoiceTypeViewModel model);
        void Update(InvoiceTypeViewModel model);
        void Delete(int id);
        InvoiceTypeViewModel GetById(int id);
    }
}
