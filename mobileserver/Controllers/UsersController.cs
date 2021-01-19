using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mobileserver.Model;
using mobileserver.DAL;

namespace mobileserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public UsersController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        [HttpGet("get")]
        public async Task<List<Users>> Get()
        {
            return await _dataAccessProvider.GetUSERRecords();
        }
        [HttpGet("getid/{id}")]
        public async Task<Users> Details(string id)
        {
            return await _dataAccessProvider.GetUSERSingleRecord(id);
        }
        [HttpPost("post")]
        public IActionResult Create([FromBody] Users u)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddUSERRecord(u);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("edit")]
        public IActionResult Edit([FromBody] Users k)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateUSERRecord(k);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string id)
        {
            var data = _dataAccessProvider.GetUSERSingleRecord(id);
            Console.WriteLine(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeleteUSERRecord(id);
            return Ok();
        }
    }
}
