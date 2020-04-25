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
            string CarInfo = $"select * from CarType c join CarInfo i on c.CarTypeID=i.cid join CarBrand b on i.bid = b.CarBrandID join AllCars a on i.CarInfoID = a.CarInfoid join Va v on a.Vaid = v.VID join CarType c2 on v.cid = c2.CarTypeID join CarBrand b2 on v.bid = b2.CarBrandID where v.Vstate = 1 ";
            return DBHelper.GetToList<CarInfo>(CarInfo);
        }



        //车辆挂靠
        public int AddVa(Va v)
        {
            string AddVa = $"insert into Va values('{v.Image}',{v.bid},'{v.CarName}',{v.Years},{v.cid},'{v.CC}','{v.AMT}',{v.Price},{v.Vstate},{v.uid})";
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





    }
}
