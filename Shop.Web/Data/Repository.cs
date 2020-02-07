
namespace Shop.Web.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtener todos los productos ordenados alfabeticamente por el campo nombre
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            return this.context.Products.OrderBy(p => p.Name);
        }

        /// <summary>
        /// Obtiene el producto por el campo Id
        /// </summary>
        /// <param name="id">Id producto</param>
        /// <returns></returns>
        public Product GetProduct(int id)
        {
            return this.context.Products.Find(id);
        }

        /// <summary>
        /// Agrega un nuevo producto a la DB
        /// </summary>
        /// <param name="product">Objeto producto</param>
        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
        }

        /// <summary>
        /// Elimina el producto de la DB
        /// </summary>
        /// <param name="product"></param>
        public void RemoveProduct(Product product)
        {
            this.context.Products.Remove(product);
        }

        /// <summary>
        /// Actualiza un producto en la DB
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product)
        {
            this.context.Products.Update(product);
        }

        /// <summary>
        /// Funcion para guardar todos los cambios del contexto 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAllSync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Funcion para verificar si el producto ya existe por medio del Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ProductExists(int id)
        {
            return this.context.Products.Any(p => p.Id == id);
        }
    }
}
