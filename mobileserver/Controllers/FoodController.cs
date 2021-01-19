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
        public Task<List<Food>> Get()
        {
            return _dataAccessProvider.GetFOODRecords();
        }
    }
}
