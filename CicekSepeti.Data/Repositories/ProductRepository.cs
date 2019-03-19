using CicekSepeti.Data.Abstract;
using CicekSepeti.Model.Entities;
using Common;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IOptions<Settings> settings) : base(settings)
        {

        }

        public async Task<IEnumerable<Product>> GetAll()  
        {

            try
            {
                return await context.Products.FindSync<Product>(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                //TODO : Exception will be managed and logged.
                throw ex;
            }
        }

        public Product GetProductById(string id)
        {
            try
            {
                return this.GetSingle(id).Result;
            }
            catch (Exception ex)
            {
                //TODO : log or manage exceptions
                throw ex;
            }
        }

        public async Task AddProduct(Product productItem)
        {
            try
            {
                await context.Products.InsertOneAsync(productItem);
            }
            catch (Exception ex)
            {
                //TODO : log or manage exception
                throw ex;
            }
        }

        public async Task<bool> RemoveProduct(string id)
        {
            try
            {
                return await this.Delete(id);
            }
            catch (Exception ex)
            {
                //TODO : log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateProduct(string id, Product product)
        {
            try
            {
                return await this.Update(id, product);
            }
            catch (Exception ex)
            {
                //TODO : log and manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAllProducts()
        {
            try
            {
                return await this.DeleteAll();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
