using MyApiDeneme.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiDeneme.DAL.Interface
{
    public interface IProductsDAL
    {
        Task<List<Products>> GetAllProductsAsync();
        Task<Products> GetProductByIdAsync(int productId);
        Task AddProductAsync(Products product);
        Task UpdateProductAsync(Products product);
        Task DeleteProductAsync(int productId);
    }
}
