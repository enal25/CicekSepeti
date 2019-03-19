using CicekSepeti.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Abstract
{
    public interface IBasketRepository : IBaseRepository<Basket>
    {
        Task<Basket> AddBasket(Basket basketItem);
    }
}
