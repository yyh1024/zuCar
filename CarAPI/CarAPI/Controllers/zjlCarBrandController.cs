﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;
using Microsoft.AspNetCore.Cors;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("first")]
    public class zjlCarBrandController : ControllerBase
    {
        CarBll bll = new CarBll();


        //品牌显示
        // GET: api/zjlCarBrand
        [HttpGet]
        public IEnumerable<CarBrand> Get()
        {
            return bll.BrandShow();
        }

        //// GET: api/zjlCarBrand/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/zjlCarBrand
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/zjlCarBrand/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
