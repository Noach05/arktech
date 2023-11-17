using ArkTech.Domains;
using ArkTech.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkTech.Services
{
    public class ProductService : IProductService
    {
        IProductRepo repo;
        public ProductService(IProductRepo repo)
        {
            this.repo = repo;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await repo.GetAllProductsAsync();
        }
        public async Task<Result> CreateProductAsync(Product nProduct)
        {
            if (nProduct == null) { return new Result(false, "Product cannot be null"); }
            else { return await repo.CreateProductAsync(nProduct); }
        }
        public async Task<Result> UpdateProductAsync(Product product)
        {
            if (product == null) { return new Result(false, "Product cannot be null"); }
            else { return await repo.UpdateProductAsync(product); }
        }
        public async Task<Result> DeleteProductAsync(Guid id)
        {
           if (id == Guid.Empty) { return new Result(false, "Empty id not accepted"); }
           else { return await repo.DeleteProductAsync(id); }
        }
        public async Task<Product> GetProductById(Guid id)
        {
            if (id == Guid.Empty) { return null; }
            else { return await repo.GetProductById(id); }
        }
    }
}
