using MyApiDeneme.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiDeneme.BLL
{
    public interface IProductsService
    {
        Task<List<Products>> GetAllProductsAsync();
        Task<Products> GetProductByIdAsync(int productId);
        Task AddProductAsync(Products product);
        Task UpdateProductAsync(Products product);
        Task DeleteProductAsync(int productId);
    }
}
