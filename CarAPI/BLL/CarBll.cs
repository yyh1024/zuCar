using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class CarBll
    {
        CarDal dal = new CarDal();
        //全部汽车显示
        public List<CarInfo> CarShow()
        {

            return dal.CarShow();
        }

        //汽车详情
        public CarInfo Find(int id)
        {
            return dal.Find(id);
        }


        //车辆挂靠
        public int AddVa(Va v)
        {
            return dal.AddVa(v);
        }

        //个人订单查询
        public List<Orders> OrdersShow(int UsersId)
        {
            return dal.OrdersShow(UsersId);
        }

        //个人挂靠信息
        public List<Va> VaShow(int UsersId)
        {
            return dal.VaShow(UsersId);
        }

        //个人信息认证,根据他的姓名和身份证是否为空来判断有没有个人认证
        public List<UserInfo> UserInfoShow(int UsersId)
        {
            return dal.UserInfoShow(UsersId);
        }

        //个人认证
        public int AddUserInfo(UserInfo u)
        {
            return dal.AddUserInfo(u);
        }

        //预定车辆
        public int AddOrders(Orders o)
        {
            return dal.AddOrders(o);
        }
    }
}
