
namespace Shop.Web.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface IRepository
    {
        void AddProduct(Product product);

        IEnumerable<Product> GetProducts();

        Product GetProducts(int id);

        bool ProductExists(int id);

        void RemoveProduct(Product product);

        Task<bool> SaveAllSync();

        void UpdateProduct(Product product);
    }
}