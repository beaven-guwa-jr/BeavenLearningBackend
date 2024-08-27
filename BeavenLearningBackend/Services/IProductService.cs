using BeavenLearningBackend.Models;

namespace BeavenLearningBackend.Services
{
    public interface IProductService
    {
        Task<int> AddProduct(ProductDTO product);
        Task<ProductDTO?> FindProduct(int productId); 
        
        Task <List<ProductDTO>> ListProducts();

        Task <ProductDTO?> UpdateProduct(ProductDTO product);

        Task DeleteProduct(int productId);   
    }
}
