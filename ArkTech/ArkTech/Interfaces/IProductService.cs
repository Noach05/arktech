using ArkTech.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Result> CreateProductAsync(Product nProduct);
        Task<Result> UpdateProductAsync(Product product);
        Task<Result> DeleteProductAsync(Guid id);
        Task<Product> GetProductById(Guid id);
    }
}
