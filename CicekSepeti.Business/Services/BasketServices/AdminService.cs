using System;
using System.Threading.Tasks;
using CicekSepeti.Business.Services.Abstract;
using CicekSepeti.Data.Abstract;
using CicekSepeti.Data.Repositories;
using CicekSepeti.Model.Entities;
using Common;
using Microsoft.Extensions.Options;

namespace CicekSepeti.Business.Services.BasketServices
{
    public class AdminService : ServiceBase, IAdminService
    {
        public IOptions<Settings> settings { get; set; }
        public AdminService(IOptions<Settings> settings)
        {
            this.settings = settings;
        }

        public async Task<bool> AddInitProducts()
        {
            IProductRepository productRepository = new ProductRepository(settings);
            await productRepository.RemoveAllProducts();
            try
            {
                await productRepository.AddProduct(new Product()
                {
                    Id = "1",
                    Name = "Test Product 1",
                    Color = 2,
                    Size = 42,
                    Quantity = 5,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    IsActive = true,
                });

                await productRepository.AddProduct(new Product()
                {
                    Id = "2",
                    Name = "Test Product 2",
                    Color = 2,
                    Size = 42,
                    Quantity = 5,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    IsActive = true,
                });

                await productRepository.AddProduct(new Product()
                {
                    Id = "3",
                    Name = "Test Product 3",
                    Color = 2,
                    Size = 42,
                    Quantity = 5,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    IsActive = true,
                });

                await productRepository.AddProduct(new Product()
                {
                    Id = "4",
                    Name = "Test Product 4",
                    Color = 2,
                    Size = 42,
                    Quantity = 5,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    IsActive = true,
                });

                await productRepository.AddProduct(new Product()
                {
                    Id = "5",
                    Name = "Test Product 5",
                    Color = 2,
                    Size = 42,
                    Quantity = 5,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    IsActive = true,
                });

                return true;
            }
            catch (Exception ex)
            {
                //Log and manage exceptions..
                throw ex;
            }
        }
    }
}
