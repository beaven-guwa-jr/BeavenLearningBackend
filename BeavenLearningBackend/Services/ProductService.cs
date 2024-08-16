using BeavenLearningBackend.Data;
using BeavenLearningBackend.Models;

namespace BeavenLearningBackend.Services
{
    public class ProductService(ApplicationDbContext context) : IProductService
    {

        

        public async Task<int> AddProduct(ProductDTO product)
        {
            var newProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price,
            };

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

        public async Task<Product?> FindProduct(int productId)
        {
           return context.Products.FirstOrDefault(x => x.Id == productId);
          
        }

        public async Task<List<Product>> ListProducts()
        {
            return context.Products.ToList();
        }

        public async  Task<Product?> UpdateProduct(ProductDTO product)
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
            return currentProduct;
        }
    }
}
