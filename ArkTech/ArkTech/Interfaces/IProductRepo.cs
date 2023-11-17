using ArkTech.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Interfaces
{
    public interface IProductRepo
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Result> CreateProductAsync(Product product);
        Task<Result> UpdateProductAsync(Product product);
        Task<Result> DeleteProductAsync(Guid id);
        Task<Product> GetProductById(Guid id);
    }
}
