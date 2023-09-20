using System;
using System.Configuration;

namespace InventoryManagementSystem
{
    public class DataAccessFactory:IDataAccessFactory
    {
        
        public IProductRepository GetDataAccess()
        {
            var databaseType = ConfigurationManager.AppSettings["DatabaseType"];

            switch(databaseType)
            {
                case "SQL": 
                     return new ProductSql();
                case "MongoDb": 
                        return new ProductMongoDb();
                default:
                    throw new ArgumentException("Invalid database type: " + databaseType);
            }
        }
    }
}