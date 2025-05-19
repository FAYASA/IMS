using Inventory.repository.Paging;
using Inventory.ViewModel.Currency;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.Currency
{
    public class CurrencyRepo : ICurrencyRepo
    {
        private readonly ApplicationDbContext _context;

        public CurrencyRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CurrencyViewModel model)
        {
            var DModel = new inventory.models.Currency()
            { 
                Name = model.Name,
                Code = model.Code,
                Description = model.Description
            };
            _context.Currencies.Add(DModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var currency = _context.Currencies.Find(id);
            if (currency != null)
            {
                _context.Currencies.Remove(currency);
                _context.SaveChanges();
            }
        }

        public Task<PaginatedList<CurrencyListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var VModel = _context.Currencies.ModelToVM().AsQueryable();
            //var VModel = Relationship.ModelToVM(_context.Currencies).AsQueryable();
            return PaginatedList<CurrencyListViewModel>.CreateAsync(VModel, pageNumber, pageSize);
        }

        public CurrencyViewModel GetById(int id)
        {
            var currency = _context.Currencies.Find(id);
            if (currency != null)
            {
                return new CurrencyViewModel
                {
                    Id = currency.Id,
                    Name = currency.Name,
                    Code = currency.Code,
                    Description = currency.Description
                };
            }
            return null;
        }

        public void Update(CurrencyViewModel model)
        {
            var currency = _context.Currencies.Find(model.Id);
            if(currency != null)
            {
                currency.Name = model.Name;
                currency.Code = model.Code;
                currency.Description = model.Description;
                _context.SaveChanges();
            }
        }
    }
}
