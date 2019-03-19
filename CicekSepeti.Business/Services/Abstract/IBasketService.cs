using CicekSepeti.Model.Entities;
using CicekSepeti.Model.Models;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Services.Abstract
{
    public interface IBasketService
    {
        Task<string> AddToBasket(BasketItem basketItem);
    }
}
