using CicekSepeti.Model.Entities;
using CicekSepeti.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Abstract
{
    public interface IBasketProductRelationRepository : IBaseRepository<BasketProductRelation>
    {
        Task AddBasketProductRelation(BasketItem basketItem);
        Task<bool> RemoveBasketProductRelation(string id);
        BasketProductRelation GetBasketProductRelationByKeys(string productId, string basketId);
    }
}
