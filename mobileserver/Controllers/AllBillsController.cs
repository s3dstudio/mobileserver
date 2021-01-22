using Microsoft.AspNetCore.Mvc;
using mobileserver.DAL;
using mobileserver.Model;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace mobileserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllBillsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public AllBillsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [Route("get")]
        [ProducesResponseType(typeof(IEnumerable<Food>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Getfood(bool withChildren)
        {
            return Ok(await _dataAccessProvider.GetFOOD(withChildren));
        }
    }
}
