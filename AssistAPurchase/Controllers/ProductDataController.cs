﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using AssistAPurchase.Utility;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistAPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDataController : ControllerBase
    {

        Repository.IProductDataRepository _productDataRepository;
        IServiceProvider _provider;
        public ProductDataController(Repository.IProductDataRepository repo, IServiceProvider provider)
        {
            this._productDataRepository = repo;
            this._provider = provider;

        }
        // GET: api/<ProductDataController>
        [HttpGet("all")]
        public IEnumerable<Models.ProductDataModel> Get()
        {
            return _productDataRepository.GetAllProducts(GetTrsanctionObjectFromContainer());
        }

        // GET api/<ProductDataController>/5
        [HttpGet("get/{id}")]
        public Models.ProductDataModel Get(string id)
        {
            var products = _productDataRepository.GetAllProducts(GetTrsanctionObjectFromContainer());
            foreach (var product in products)
            {
                if (product.ProductId == id)
                {
                    return product;
                }
            }
            return null;
        }

        // POST api/<ProductDataController>
        [HttpPost("new")]
        public void Post([FromBody] Models.ProductDataModel value)
        {
            _productDataRepository.AddNewProduct(value, GetTrsanctionObjectFromContainer());
        }

        // PUT api/<ProductDataController>/5
        [HttpPut("update/{id}")]
        public void Put(string id, [FromBody] Models.ProductDataModel value)
        {
            _productDataRepository.UpdateProductInfo(id, value, GetTrsanctionObjectFromContainer());
        }

        // DELETE api/<ProductDataController>/5
        [HttpDelete("remove/{id}")]
        public void Delete(string id)
        {
            _productDataRepository.RemoveProduct(id, GetTrsanctionObjectFromContainer());
        }

        //dependency injection
        ITransactionManager GetTrsanctionObjectFromContainer()
        {
            return this._provider.GetService<ITransactionManager>();
        }
    }
}
