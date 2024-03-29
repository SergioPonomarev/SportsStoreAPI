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
            Repository = (IRepository)GlobalConfiguration
                .Configuration
                .DependencyResolver
                .GetService(typeof(IRepository));
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

        [Authorize(Roles = "Administrators")]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await Repository.SaveProductAsync(product);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize(Roles = "Administrators")]
        public async Task DeleteProduct(int id)
        {
            await Repository.DeleteProductAsync(id);
        }
    }
}
