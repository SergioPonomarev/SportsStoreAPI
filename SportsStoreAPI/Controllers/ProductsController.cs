﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SportsStoreAPI.Models;

namespace SportsStoreAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private IRepository Repository { get; set; }

        public ProductsController()
        {
            Repository = new ProductRepository();
        }

        public IEnumerable<Product> GetProducts()
        {
            return Repository.Products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            //return Repository.Products.Where(p => p.Id == id).FirstOrDefault();
            Product result = Repository.Products.FirstOrDefault(p => p.Id == id);

            return result == null 
                ? (IHttpActionResult)BadRequest("No Product Found") 
                : Ok(result);
        }

        public async Task PostProduct(Product product)
        {
            await Repository.SaveProductAsync(product);
        }

        [Authorize(Roles = "Administrators")]
        public async Task DeleteProduct(int id)
        {
            await Repository.DeleteProductAsync(id);
        }
    }
}