﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Model;
using Microsoft.AspNetCore.Cors;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("first")]
    [ApiController]
    public class zjlCarType5Controller : ControllerBase
    {
        CarBll bll = new CarBll();
        // GET: api/zjlCar5
        [HttpGet]
        public IEnumerable<CarType> Get()
        {
            return bll.TypeShow();
        }

        //// GET: api/zjlCar5/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/zjlCar5
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/zjlCar5/5
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
