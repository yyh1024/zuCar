using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //预定表（订单表）
    public class Orders
    {
        public int OrdersID { get; set; }
        public string Oid { get; set; }
        public int uid { get; set; }
        public int CarInfoid { get; set; }
        public string Useing { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Driver { get; set; }
        public decimal Price { get; set; }
        public int ZT { get; set; }
        public int Hitch { get; set; }
        public string CarName { get; set; }
    }
}
