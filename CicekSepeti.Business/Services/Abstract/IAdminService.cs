using CicekSepeti.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Services.Abstract
{
    public interface IAdminService
    {
        Task<bool> AddInitProducts();
    }
}
