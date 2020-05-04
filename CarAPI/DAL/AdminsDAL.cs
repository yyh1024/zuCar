using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AdminsDAL
    {

        //车辆预定信息
        public List<Orders> OrderShow()
        {
            string str = $"select * from Orders";
            return DBHelper.GetToList<Orders>(str);
        }

        //用户挂靠的车辆信息
        public List<Va> VaShow()
        {
            string str = $"select * from CarType c join Va v on c.CarTypeID=v.cid join CarBrand b on v.bid = b.CarBrandID";
            return DBHelper.GetToList<Va>(str);
        }

        //新增车辆
        public int AddCarInfo(CarInfo c)
        {
            c.Address = "郑州市中原区建设路西三环百车汇汽车租赁有限公司";
            string str = $"insert into CarInfo values('{c.Image}',{c.bid},'{c.CarName},{c.Years},{c.cid},'{c.CC}',{c.Count},'{c.AMT}',{c.Price}')";
            return DBHelper.ExecuteNonQuery(str);
        }

        //查看故障报修原因
        public Breakdown GetBreakdown(int id)
        {
            string str = "select * from Breakdown where BreakdownID=" + id;
            return DBHelper.GetToList<Breakdown>(str)[0];
        }

        //审批
        public int UptVa(Va v)
        {
            string str = $"Update Va set Vstate = 1 where VID={v.VID}";
            return DBHelper.ExecuteNonQuery(str);
        }

        //修改故障状态为：报修通过
        public int UptOrdersAgree(Orders o)
        {
            string str = $"Update Orders set Hitch=3 where OrdersID={o.OrdersID}";
            return DBHelper.ExecuteNonQuery(str);
        }

        //修改故障状态：有待商议
        public int UptOrdersDisAgree(Orders o)
        {
            string str = $"Update Orders set Hitch=4 where OrdersID={o.OrdersID}";
            return DBHelper.ExecuteNonQuery(str);
        }

    }
}
