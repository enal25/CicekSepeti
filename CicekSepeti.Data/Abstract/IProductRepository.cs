using CicekSepeti.Model.Entities;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Abstract
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetProductById(string id);
        Task AddProduct(Product productItem);
        Task<bool> RemoveProduct(string id);
        Task<bool> UpdateProduct(string id, Product product);
        Task<bool> RemoveAllProducts();


    }
}
