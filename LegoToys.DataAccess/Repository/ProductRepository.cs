using LegoToys.DataAccess.Repository.IRepository;
using LegoToys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoToys.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Product product)
        {
            var objProduct = _db.Products.FirstOrDefault(p => p.Id == product.Id);
            if (objProduct != null)
            {
                objProduct.Title = product.Title;
                objProduct.Description = product.Description;              
                objProduct.ISBN = product.ISBN;
                objProduct.Manufacturer = product.Manufacturer;
                objProduct.ListPrice = product.ListPrice;
                objProduct.Price = product.Price;
                objProduct.Price50 = product.Price50;
                objProduct.Price100 = product.Price100;
                objProduct.CategoryId = product.CategoryId;
                objProduct.CoverTypeId = product.CoverTypeId;
                if (product.ImageUrl != null)
                {
                    objProduct.ImageUrl = product.ImageUrl;
                }
                _db.Products.Update(objProduct);
            }
            
        }
    }
}
