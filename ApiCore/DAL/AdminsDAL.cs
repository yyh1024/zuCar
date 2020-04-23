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

        //挂靠车辆信息
        public List<Va> VaShow()
        {
            string str = $"select * from Va";
            return DBHelper.GetToList<Va>(str);
        }

        //新增车辆
        public int AddCarInfo(CarInfo c)
        {
            c.Address = "郑州市中原区建设路西三环百车汇汽车租赁有限公司";
            string AddCar = $"insert into CarInfo values('{c.Image}',{c.bid},'{c.CarName},{c.Years},{c.cid},'{c.CC}',{c.Count},'{c.AMT}',{c.Price}')";
            return DBHelper.ExecuteNonQuery(AddCar);
        }
    }
}
