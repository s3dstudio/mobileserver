using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mobileserver.DAL;
using mobileserver.Model;

namespace mobileserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsCartController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public FoodsCartController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        [HttpGet("get")]
        public async Task<List<FoodsCart>> Get()
        {
            return await _dataAccessProvider.GetFCRecords();
        }
        [HttpGet("getid/{id}")]
        public async Task<FoodsCart> Details(string id)
        {
            return await _dataAccessProvider.GetFCSingleRecord(id);
        }
        [HttpPost("post")]
        public IActionResult Create([FromBody] FoodsCart food)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddFCRecord(food);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("edit")]
        public IActionResult Edit([FromBody] FoodsCart k)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateFCRecord(k);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string id)
        {
            var data = _dataAccessProvider.GetFCSingleRecord(id);
            Console.WriteLine(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteFCRecord(id);
            return Ok();
        }
    }
}
