using Inventory.ViewModel.Bill;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.Paging
{

    /// <summary>
    /// ✅ The purpose of PaginatedList (Microsoft Paging) is:
    /// ➡️ To split large amounts of data into small pages(like 10 items per page),
    /// instead of loading 1000 items at once, which would be very slow and heavy.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        internal static Task<PaginatedList<BillTypeListViewModel>> CreateAsync(IQueryable<BillTypeListViewModel> vm, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
