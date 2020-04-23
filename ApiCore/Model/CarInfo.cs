using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //汽车信息表
    public class CarInfo
    {
        public int CarInfoID { get; set; }
        public string Image { get; set; }
        public int bid { get; set; }
        public string CarName { get; set; }
        public int Years { get; set; }
        public int cid { get; set; }
        public string CC { get; set; }
        public string AMT { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
    }
}
