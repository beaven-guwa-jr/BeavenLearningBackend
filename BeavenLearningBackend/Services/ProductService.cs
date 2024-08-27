using AutoMapper;
using BeavenLearningBackend.Data;
using BeavenLearningBackend.Models;

namespace BeavenLearningBackend.Services
{
    public class ProductService(ApplicationDbContext context, IMapper mapper) : IProductService
    {

        public async Task<int> AddProduct(ProductDTO product)
        {
            var newProduct = mapper.Map<Product>(product);


            context.Products.Add(newProduct);

            await context.SaveChangesAsync();
            return newProduct.Id;
        }

        public async Task DeleteProduct(int productId)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.IsDeleted = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task<ProductDTO?> FindProduct(int productId)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == productId);
            var result = mapper.Map<ProductDTO>(product);
            return result;

        }

        public async Task<List<ProductDTO>> ListProducts()
        {
            var products = context.Products.ToList();
            var result = mapper.Map<List<ProductDTO>>(products);
            return result;
        }

        public async Task<ProductDTO?> UpdateProduct(ProductDTO product)
        {
            var currentProduct = context.Products.FirstOrDefault(x => x.Name == product.Name);
            if (currentProduct == null)
            {
                return null;
            }
            currentProduct.Price = product.Price;
            currentProduct.Name = product.Name;

            context.Update(currentProduct);
            await context.SaveChangesAsync();

            var updatedProduct = await FindProduct(currentProduct.Id);
            return updatedProduct;
        }
    }
}
