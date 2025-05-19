using inventory.models;
using Inventory.repository.Paging;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.repository.ProductService
{
    public class ProductRepo : IProductRepo
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductRepo(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void Add(ProductViewModel model)
        {
            var vm = new inventory.models.Product()
            {
                ProductName = model.ProductName,
                ProductCode = model.ProductCode,
                Barcode = model.Barcode,
                Description = model.Description,
                ProductImage = model.ProductImage,
                MeasureUnitId = model.MeasureUnitId,
                BuyingPrice = model.BuyingPrice,
                SellingPrice = model.SellingPrice,
                BranchId = model.BranchId,
                CurrencyId = model.CurrencyId,
                ProductTypeId = model.ProductTypeId
            };
            _context.products.Add(vm);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _context.products.Where(x => x.ProductId == id).FirstOrDefault();
            if (model != null)
            {
                _context.products.Remove(model);
                _context.SaveChanges();
            }
        }

        public Task<PaginatedList<ProductListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var productList = _context.products;
            var vm = productList.ModelToVM().AsQueryable();
            return PaginatedList<ProductListViewModel>.CreateAsync(vm, pageNumber, pageSize);
        }

        public ProductViewModel GetById(int id)
        {
            var model = _context.products.Where(x => x.ProductId == id).FirstOrDefault();
            if (model != null)
            {
                var vm = new ProductViewModel()
                {
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    ProductCode = model.ProductCode,
                    Barcode = model.Barcode,
                    Description = model.Description,
                    ProductImage = model.ProductImage,
                    MeasureUnitId = model.MeasureUnitId,
                    BuyingPrice = model.BuyingPrice,
                    SellingPrice = model.SellingPrice,
                    BranchId = model.BranchId,
                    CurrencyId = model.CurrencyId,
                    ProductTypeId = model.ProductTypeId
                };
                return vm;
            }
            return null;
        }

        public List<SelectListItem> GetProductTypesForDropdown()
        {

            return _context.productTypes.Select(pt => new SelectListItem
            {
                Value = pt.ProductTypeId.ToString(),
                Text = pt.ProductTypeName
            }).ToList();

            //var productTypes = _context.productTypes.ToList();
            //var productTypeList = new List<SelectListItem>();
            //foreach (var item in productTypes)
            //{
            //    productTypeList.Add(new SelectListItem
            //    {
            //        Value = item.ProductTypeId.ToString(),
            //        Text = item.ProductTypeName
            //    });
            //}
            //return productTypeList;
        }
        public void Update(ProductViewModel model)
        {
            var data = _context.products
                .Where(x => x.ProductId == model.ProductId).FirstOrDefault();
            if (data != null)
            {
                data.ProductName = model.ProductName;
                data.ProductCode = model.ProductCode;
                data.Barcode = model.Barcode;
                data.Description = model.Description;
                data.ProductImage = model.ProductImage;
                data.MeasureUnitId = model.MeasureUnitId;
                data.BuyingPrice = model.BuyingPrice;
                data.SellingPrice = model.SellingPrice;
                data.BranchId = model.BranchId;
                data.CurrencyId = model.CurrencyId;
                data.ProductTypeId = model.ProductTypeId;
                _context.SaveChanges();
            }
        }
        public List<SelectListItem> GetBranchForDropdown()
        {
            return _context.Branches.Select(b => new SelectListItem
            {
                Value = b.BranchId.ToString(),
                Text = b.BranchName
            }).ToList();
        }

        public List<SelectListItem> GetCurrencyForDropdown()
        {
            return _context.Currencies.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }

        public async Task<string> UploadImageAsync(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                throw new ArgumentException("Invalid image file");

            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return "/uploads/" + uniqueFileName; // return relative path
        }

    }
}
