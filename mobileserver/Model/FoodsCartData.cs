using System;
using System.Collections.Generic;

namespace mobileserver.Model
{
    public class FoodsCartData
    {
        public string idCart { get; set; }
        public int table { get; set; }
        public int totalprice { get; set; }
        public string status { get; set; }
        public string time { get; set; }
        public List<FoodsCartDetailData> listItem { get; set; }

        public FoodsCartData()
        {
            listItem = new List<FoodsCartDetailData>();
        }
    }
}
