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
    public class FoodsCartDetailController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public FoodsCartDetailController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        [HttpGet("get")]
        public async Task<List<FoodsCartDetail>> Get()
        {
            return await _dataAccessProvider.GetFCDTRecords();
        }
        [HttpGet("getid/{id}")]
        public async Task<FoodsCartDetail> Details(string id)
        {
            return await _dataAccessProvider.GetFCDTSingleRecord(id);
        }
        [HttpPost("post")]
        public IActionResult Create([FromBody] FoodsCartDetailData f)
        {
            if (ModelState.IsValid)
            {
                FoodsCartDetail fcdetail = new FoodsCartDetail();

                fcdetail.idfcdetail = f.idfcdetail;
                fcdetail.idfoodscart = f.idfoodscart;
                fcdetail.idfood = f.idfood;
                fcdetail.amount = f.amount;
                fcdetail.size = f.size;

                _dataAccessProvider.AddFCDTRecord(fcdetail);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("edit")]
        public IActionResult Edit([FromBody] FoodsCartDetail k)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.UpdateFCDTRecord(k);
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string id)
        {
            var data = _dataAccessProvider.GetFCDTSingleRecord(id);
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
