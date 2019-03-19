using CicekSepeti.Data.Abstract;
using CicekSepeti.Model.Entities;
using CicekSepeti.Model.Models;
using Common;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repositories
{
    public class BasketProductRelationRepository : BaseRepository<BasketProductRelation>, IBasketProductRelationRepository
    {
        public BasketProductRelationRepository(IOptions<Settings> settings) : base(settings)
        {

        }

        public async Task AddBasketProductRelation(BasketItem basketItem)
        {
            try
            {
                var basketProductRelation = new BasketProductRelation()
                {
                    Id = Guid.NewGuid().ToString(),
                    BasketId = basketItem.BasketId,
                    ProductId = basketItem.Product.Id,
                    Quantity = basketItem.Product.Quantity,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    IsActive = true
                };
                await this.Add(basketProductRelation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BasketProductRelation GetBasketProductRelationByKeys(string productId, string basketId)
        {
            try
            {
                return this.GetSingle(rel => rel.ProductId == productId && rel.BasketId == basketId).Result;
            }
            catch (Exception ex)
            {
                //TODO : log or manage exceptions
                throw ex;
            }
        }

        public Task<bool> RemoveBasketProductRelation(string id)
        {
            throw new NotImplementedException();
        }
    }
}
