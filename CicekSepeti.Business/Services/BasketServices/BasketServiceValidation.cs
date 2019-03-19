using CicekSepeti.Business.Services.Abstract;
using CicekSepeti.Data.Abstract;
using CicekSepeti.Data.Repositories;
using CicekSepeti.Model.Models;
using Common.Constants;
using Common.Resources;

namespace CicekSepeti.Business.Services.BasketServices
{
    public partial class BasketService
    {
        private bool ValidateBasket(BasketItem basketItem, ref string result)
        {
            if (!CheckNull(basketItem, ref result))
                return false;

            if (!CheckStock(basketItem, ref result))
                return false;

            if (!CheckBasketProductRelationExist(basketItem, ref result))
                return false;

            return true;
        }

        private bool CheckNull(BasketItem basketItem, ref string result)
        {
            if (basketItem == null || basketItem.Product == null || string.IsNullOrEmpty(basketItem.BasketId))
                result = CommonErrorCodes.MissingParameters;

            if (result != CommonErrorCodes.OK)
                return false;

            return true;
        }

        private bool CheckStock(BasketItem basketItem, ref string result)
        {
            IProductRepository productRepository = new ProductRepository(settings);

            var productInStock = productRepository.GetProductById(basketItem.Product.Id);

            if (productInStock == null)
            {
                result = CommonErrorCodes.NoSuchProduct;
                return false;
            }

            if (productInStock.Quantity < basketItem.Product.Quantity)
            {
                result = CommonErrorCodes.NotInStock;
                return false;
            }

            return true;
        }

        private bool CheckBasketProductRelationExist(BasketItem basketItem, ref string result)
        {
            IBasketProductRelationRepository basketProductRelationRepository = new BasketProductRelationRepository(settings);
            var basketProductRelation = basketProductRelationRepository.GetBasketProductRelationByKeys(basketItem.Product.Id, basketItem.BasketId);
            if (basketProductRelation != null)
            {
                result = CommonErrorCodes.AlreadyExistInBasket;
                return false;
            }

            return true;
        }
    }
}
