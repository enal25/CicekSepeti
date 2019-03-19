using Common;
using CicekSepeti.Model.Entities;
using MongoDB.Driver;

namespace CicekSepeti.Data.DbContext
{
    public class CicekSepetiContext<T> where T : class
    {
        private readonly IMongoDatabase database = null;

        public CicekSepetiContext(Microsoft.Extensions.Options.IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            database = client?.GetDatabase(settings.Value.Database);
        }

        //TODO : Generic structure for database collections(objects/tables).
        public IMongoCollection<T> dbModel
        {
            get
            {
                return database.GetCollection<T>(nameof(T));
            }
        }


        public IMongoCollection<Product> Products
        {
            get
            {
                return database.GetCollection<Product>(nameof(Product));
            }
        }

        public IMongoCollection<Basket> Baskets
        {
            get
            {
                return database.GetCollection<Basket>(nameof(Basket));
            }
        }

        public IMongoCollection<BasketProductRelation> BasketProductRelations
        {
            get
            {
                return database.GetCollection<BasketProductRelation>(nameof(BasketProductRelation));
            }
        }
    }
}
