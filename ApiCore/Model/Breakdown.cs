using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //故障原因表
    public class Breakdown
    {
        public int BreakdownID { get; set; }
        public string Reson { get; set; }
        public string Phone { get; set; }
        public int OrdersID { get; set; }
    }
}
