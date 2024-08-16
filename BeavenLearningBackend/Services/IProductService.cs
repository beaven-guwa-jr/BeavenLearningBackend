using BeavenLearningBackend.Models;

namespace BeavenLearningBackend.Services
{
    public interface IProductService
    {
        Task<int> AddProduct(ProductDTO product);
        Task<Product?> FindProduct(int productId); 
        
        Task <List<Product>> ListProducts();

        Task <Product?> UpdateProduct(ProductDTO product);

        Task DeleteProduct(int productId);   
    }
}
