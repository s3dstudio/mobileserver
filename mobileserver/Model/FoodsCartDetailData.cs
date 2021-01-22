using System;
namespace mobileserver.Model
{
    public class FoodsCartDetailData
    {
        public string idfcdetail { get; set; }
        public string idfoodscart { get; set; }
        public string idfood { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public int amount { get; set; }
        public string size { get; set; }


        public FoodsCartDetailData()
        {
        }
    }
}
