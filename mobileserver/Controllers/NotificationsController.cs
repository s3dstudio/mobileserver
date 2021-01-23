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
    public class NotificationsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public NotificationsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        [HttpGet("get")]
        public async Task<List<Notifications>> Get()
        {
            return await _dataAccessProvider.GetNTRecords();
        }
        [HttpGet("getid/{id}")]
        public async Task<Notifications> Details(string id)
        {
            return await _dataAccessProvider.GetNTSingleRecord(id);
        }
        [HttpPost("post")]
        public IActionResult Create([FromBody] Notifications food)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddNTRecord(food);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("edit")]
        public IActionResult Edit([FromBody] Notifications k)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateNTRecord(k);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string id)
        {
            _dataAccessProvider.DeleteNTRecord(id);
            return Ok();
        }
    }
}
