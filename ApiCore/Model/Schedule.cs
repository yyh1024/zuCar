using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //车辆预定记录表
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public int uid { get; set; }
        public int OrdersID { get; set; }
        public bool Hitch { get; set; } //故障

    }
}
