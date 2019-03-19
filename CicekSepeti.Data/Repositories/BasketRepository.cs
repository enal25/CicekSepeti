using CicekSepeti.Data.Abstract;
using CicekSepeti.Model.Entities;
using Common;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repositories
{
    public class BasketRepository : BaseRepository<Basket>, IBasketRepository
    {
        public BasketRepository(IOptions<Settings> settings) : base(settings)
        {

        }

        public async Task<Basket> AddBasket(Basket basket)
        {
            try
            {
                var basketObj = new Basket()
                {
                    Id = basket.Id,
                    CreateDate = DateTime.Now,
                    IsActive = true,
                    ModifyDate = DateTime.Now
                };

                await this.Add(basketObj);
                return await this.GetSingle(basket.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
