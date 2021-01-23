using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mobileserver.DAL;
using mobileserver.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobileserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public FoodController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        [HttpGet("get")]
        public async Task<List<Food>> Get()
        {
            return await _dataAccessProvider.GetFOODRecords();
        }
        [HttpGet("getid/{id}")]
        public async Task<Food> Details (string id)
        {
            return await _dataAccessProvider.GetFOODSingleRecord(id);
        }
        [HttpPost("post")]
        public IActionResult Create([FromBody] Food food)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddFOODRecord(food);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("edit")]
        public IActionResult Edit([FromBody] Food k)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateFOODRecord(k);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string id)
        {
            _dataAccessProvider.DeleteFOODRecord(id);
            return Ok();
        }
    }
}
