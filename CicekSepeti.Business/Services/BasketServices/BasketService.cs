using CicekSepeti.Business.Services.Abstract;
using CicekSepeti.Data.Abstract;
using CicekSepeti.Data.Repositories;
using CicekSepeti.Model.Entities;
using CicekSepeti.Model.Models;
using Common;
using Common.Constants;
using Common.Resources;
using Microsoft.Extensions.Options;
using System;
using System.Resources;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Services.BasketServices
{
    public partial class BasketService : ServiceBase, IBasketService
    {
        //public BasketService(IOptions<Settings> settings) : base(settings)
        //{

        //}
        public IOptions<Settings> settings { get; set; }
        public BasketService(IOptions<Settings> settings)
        {
            this.settings = settings;
        }

        public async Task<string> AddToBasket(BasketItem basketItem)
        {
            string result = CommonErrorCodes.OK;

            if (!ValidateBasket(basketItem, ref result))
                return ResourceHelper.ReadFromResource(result);

            IBasketRepository basketRepository = new BasketRepository(settings);
            var basket = await basketRepository.GetSingle(basketItem.BasketId);

            if (basket == null)
                basket = await basketRepository.AddBasket(new Basket() { Id = basketItem.BasketId });

            IBasketProductRelationRepository basketProductRelationRepository = new BasketProductRelationRepository(settings);
            await basketProductRelationRepository.AddBasketProductRelation(basketItem);

            //Stock update on current product.quantity by subtracting request.quantity
            IProductRepository productRepository = new ProductRepository(settings);
            var product = productRepository.GetProductById(basketItem.Product.Id);
            product.Quantity -= basketItem.Product.Quantity;
            await productRepository.UpdateProduct(product.Id, product);

            return ResourceHelper.ReadFromResource(result);
        }

        public async Task<string> RemoveFromBasket(BasketItem basketItem)
        {
            string result = CommonErrorCodes.OK;

            return ResourceHelper.ReadFromResource(result);
        }

    }
}
