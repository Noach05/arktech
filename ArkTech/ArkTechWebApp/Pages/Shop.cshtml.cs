using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ArkTechWebApp.DTO;
using ArkTech.Domains;
using ArkTech.Services;
using ArkTech.Interfaces;

namespace ArkTechWebApp.Pages
{
    public class ShopModel : PageModel
    {
        private const string PRODUCTS_DETAILS_URL = "/ProductDetails";
        private IProductService productService;

        public bool IsLoading { get; set; } = true;
        public List<ProductDTO> productDTOs = new List<ProductDTO>();

        public ShopModel(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task OnGetAsync()
        {
            await LoadAllProducts();
        }
        public async Task LoadAllProducts()
        {
            var allProducts = await productService.GetProductsAsync();
            if (allProducts is not null)
            {
                productDTOs = allProducts.Select(product => new ProductDTO(product)).ToList();
            }
        }
    }
}
