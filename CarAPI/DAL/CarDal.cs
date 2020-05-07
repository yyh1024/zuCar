using System;
using Model;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public class CarDal
    {

        //全部汽车显示
        public List<CarInfo> CarShow()
        {
            string CarInfo = $"select * from CarType c join CarInfo i on c.CarTypeID=i.cid join CarBrand b on i.bid = b.CarBrandID";
            return DBHelper.GetToList<CarInfo>(CarInfo);
        }

        //汽车详情
        public CarInfo Find(int id)
        {
            string CarInfo = $"select * from CarType c join CarInfo i on c.CarTypeID=i.cid join CarBrand b on i.bid = b.CarBrandID join AllCars a on i.CarInfoID = a.CarInfoid join Va v on a.Vaid = v.VID join CarType c2 on v.cid = c2.CarTypeID join CarBrand b2 on v.bid = b2.CarBrandID where v.Vstate = 1 i.CarInfoID={id} ";
            return DBHelper.GetToList<CarInfo>(CarInfo)[0];
        }

        //车辆挂靠
        public int AddVa(Va v)
        {
            string AddVa = $"insert into Va values('{v.Image}',{v.bid},'{v.CarName}',{v.Years},{v.cid},'{v.CC}','{v.AMT}',{v.Price},Vstate,{v.uid})";
            return DBHelper.ExecuteNonQuery(AddVa);
        }

        //个人订单查询
        public List<Orders> OrdersShow(int UsersId)
        {
            string Str = $"select * from CarType c join CarInfo i on c.CarTypeID=i.cid join CarBrand b on i.bid=b.CarBrandID join Orders o on i.CarInfoID=o.CarInfoid join Users u on o.uid=u.Uid where o.uid={UsersId}";
            return DBHelper.GetToList<Orders>(Str);
        }

        //个人挂靠信息
        public List<Va> VaShow(int UsersId)
        {
            string Str = $"select * from CarType c join Va v on c.CarTypeID=v.cid join CarBrand b on v.bid=b.CarBrandID where v.uid={UsersId}";
            return DBHelper.GetToList<Va>(Str);
        }

        //个人信息认证,根据他的姓名和身份证是否为空来判断有没有个人认证
        public List<UserInfo> UserInfoShow(int UsersId)
        {
            string Str = $"select * from Users u1 join UserInfo u2 on u1.Uid=u2.uid where u1.Uid={UsersId}";
            return DBHelper.GetToList<UserInfo>(Str);
        }

        //个人认证
        public int AddUserInfo(UserInfo u)
        {
            string str = $"insert into UserInfo values({u.uid},'{u.UName}','{u.IDcard}')";
            return DBHelper.ExecuteNonQuery(str);
        }


        //预定车辆
        public int AddOrders(Orders o)
        {
            string str = $"insert into Orders values('{o.Oid}',{o.uid},{o.CarInfoid},'{o.Useing}','{o.StartTime}','{o.EndTime}',{o.Driver},{o.Price},ZT,'Hitch') ";
            return DBHelper.ExecuteNonQuery(str);
        }

        //车辆类型
        public List<CarType> TypeShow()
        {
            string str = "select * from CarType";
            return DBHelper.GetToList<CarType>(str);
        }

        //车辆品牌
        public List<CarBrand> BrandShow()
        {
            string str = "select * from CarBrand";
            return DBHelper.GetToList<CarBrand>(str);
        }
        //添加故障原因
        public int AddBreakdown(Breakdown m)
        {
            string sql = string.Format("insert into Breakdown values('{0}','{1}','{2}')",m.Reson,m.Phone,m.OrdersID);
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}
