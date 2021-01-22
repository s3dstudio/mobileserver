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
    public class FoodsCartController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public FoodsCartController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        [HttpGet("get")]
        public async Task<List<FoodsCartData>> Get()
        {
            List<foodscart> foodsCarts = await _dataAccessProvider.GetFCRecords();
            List<FoodsCartDetail> foodsCartDetails = await _dataAccessProvider.GetFCDTRecords();
            List<Food> foods = await _dataAccessProvider.GetFOODRecords();

            List<FoodsCartData> foodsCartsData = new List<FoodsCartData>();

            foreach (var item in foodsCarts)
            {
                FoodsCartData fcdata = new FoodsCartData();
                fcdata.idCart = item.idcart;
                fcdata.status = item.status;
                fcdata.table = item.table;
                fcdata.totalprice = item.totalprice;
                fcdata.time = item.time;

                foreach (var fcdt in foodsCartDetails)
                {
                    if (fcdt.idfoodscart == item.idcart)
                    {
                        FoodsCartDetailData foodsCartDetailData = new FoodsCartDetailData();
                        foodsCartDetailData.idfcdetail = fcdt.idfcdetail;
                        foodsCartDetailData.idfoodscart = fcdt.idfoodscart;
                        foodsCartDetailData.size = fcdt.size;
                        foodsCartDetailData.amount = fcdt.amount;
                        foodsCartDetailData.idfood = fcdt.idfood;

                        foreach(var food in foods)
                        {
                            if(fcdt.idfood == food.idfood)
                            {
                                foodsCartDetailData.title = food.title;
                                foodsCartDetailData.price = food.price;
                                break;
                            }
                        }
                        fcdata.listItem.Add(foodsCartDetailData);
                    }
                }

                foodsCartsData.Add(fcdata);
            }


            return foodsCartsData;
        }
        [HttpGet("getid/{id}")]
        public async Task<foodscart> Details(string id)
        {
            return await _dataAccessProvider.GetFCSingleRecord(id);
        }
        [HttpPost("post")]
        public IActionResult Create([FromBody] foodscart food)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddFCRecord(food);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("edit")]
        public IActionResult Edit([FromBody] foodscart k)
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
