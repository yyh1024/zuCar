using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //（用户）车辆挂靠表
    public class Va
    {
        public int VID { get; set; }
        public string Image { get; set; }
        public int bid { get; set; }
        public string CarName { get; set; }
        public int Years { get; set; }
        public int cid { get; set; }
        public string CC { get; set; }
        public string AMT { get; set; }
        public decimal Price { get; set; }
        public bool Vstate { get; set; }
        public int uid { get; set; }
    }
}
