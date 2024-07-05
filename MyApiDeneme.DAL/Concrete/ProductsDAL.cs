using Microsoft.EntityFrameworkCore;
using MyApiDeneme.Core.Entities;
using MyApiDeneme.DAL.Context;
using MyApiDeneme.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiDeneme.DAL.Concrete
{
    public class ProductsDAL : IProductsDAL
    {
        private readonly NorthwindDbContext _db;

        public ProductsDAL(NorthwindDbContext db)
        {
            _db = db;
        }

        public async Task AddProductAsync(Products product)
        {
            if (product == null) 
                throw new ArgumentNullException(nameof(product));

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _db.Products.FindAsync(productId);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Products>> GetAllProductsAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Products> GetProductByIdAsync(int productId)
        {
            return await _db.Products.FindAsync(productId);
        }

        public async Task UpdateProductAsync(Products product)
        {
            if (product == null) 
                throw new ArgumentNullException(nameof(product));

            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            
        }
    }
}
