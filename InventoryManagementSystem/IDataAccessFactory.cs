namespace InventoryManagementSystem
{
    public interface IDataAccessFactory
    {
         IProductRepository GetDataAccess();
    }
}
