using Inventory.repository.Paging;
using Inventory.ViewModel.Currency;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.Currency
{
    public interface ICurrencyRepo
    {
        Task<PaginatedList<CurrencyListViewModel>> GetAll(int pageSize, int pageNumber);
        void Add(CurrencyViewModel model);
        void Update(CurrencyViewModel model);
        void Delete(int id);
        CurrencyViewModel GetById(int id);
    }
}
