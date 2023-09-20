using System.Collections.Generic;

namespace InventoryManagementSystem
{
    public class ProductMongoDb : IProductRepository
    {
        public void DeleteProduct(string name)
        {
            throw new System.NotImplementedException();
        }

        public Product GetProduct(string name)
        {
            throw new System.NotImplementedException();
        }

        public void InsertProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> SelectAllProducts()
        {
            throw new System.NotImplementedException();
        }
        void IProductRepository.DeleteProduct(string name)
        {
            throw new System.NotImplementedException();
        }

        Product IProductRepository.GetProduct(string name)
        {
            throw new System.NotImplementedException();
        }

        void IProductRepository.InsertProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        List<Product> IProductRepository.SelectAllProducts()
        {
            throw new System.NotImplementedException();
        }

        void IProductRepository.UpdateProduct(Product product, string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
