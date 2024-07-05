using MyApiDeneme.Core.Entities;
using MyApiDeneme.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiDeneme.BLL
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsDAL _productsDAL;

        public ProductsService(IProductsDAL productsDAL)
        {
            _productsDAL = productsDAL;
        }

        public async Task AddProductAsync(Products product)
        {
            if (product == null) 
                throw new ArgumentNullException(nameof(product));

            await _productsDAL.AddProductAsync(product);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _productsDAL.DeleteProductAsync(productId);
        }

        public async Task<List<Products>> GetAllProductsAsync()
        {
            return await _productsDAL.GetAllProductsAsync();
        }

        public async Task<Products> GetProductByIdAsync(int productId)
        {
            return await _productsDAL.GetProductByIdAsync(productId);
        }

        public async Task UpdateProductAsync(Products product)
        {
            if(product == null) 
                throw new ArgumentNullException(nameof(product));

            await _productsDAL.UpdateProductAsync(product);
        }
    }
}
