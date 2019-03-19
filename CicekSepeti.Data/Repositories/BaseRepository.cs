using CicekSepeti.Data.Abstract;
using CicekSepeti.Data.DbContext;
using CicekSepeti.Model;
using Common;
using Common.Constants;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repositories
{
    public class BaseRepository<T> : BaseStartupRepository, IBaseRepository<T>
        where T : class, IEntityBase
    {
        protected CicekSepetiContext<T> context = null;

        public BaseRepository(IOptions<Settings> settings) : base(settings)
        {
            context = context ?? new CicekSepetiContext<T>(settings);
        }
        
        public async Task Add(T entity)
        {
            await context.dbModel.InsertOneAsync(entity);
        }

        public async Task<bool> Delete(string id)
        {
            DeleteResult actionResult = await context.dbModel.DeleteOneAsync(Builders<T>.Filter.Eq(FieldConstants.Id, id));
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<bool> DeleteAll()
        {
            DeleteResult actionResult
                    = await context.Products.DeleteManyAsync(new BsonDocument());

            return actionResult.IsAcknowledged
                && actionResult.DeletedCount > 0;
        }

        public async Task<T> GetSingle(string id)
        {
            return await context.dbModel.Find(model => model.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            return await context.dbModel.Find(predicate).FirstOrDefaultAsync();
        }

        public ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public Task<IEnumerable<T>> FindBy(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(string id, T entity)
        {
            ReplaceOneResult actionResult = await context.dbModel.ReplaceOneAsync(
                    p => p.Id.Equals(id), entity);

            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

    }
}
