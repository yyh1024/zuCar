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
            string CarInfo = $"select * from CarType c join CarInfo i on c.CarTypeID=i.cid join CarBrand b on i.bid = b.CarBrandIDjoin AllCars a on i.CarInfoID = a.CarInfoidjoin Va v on a.Vaid = v.VIDjoin CarType c2 on v.cid = c2.CarTypeIDjoin CarBrand b2 on v.bid = b2.CarBrandID where v.Vstate = 1 ";
            return DBHelper.GetToList<CarInfo>(CarInfo);
        }


        //新增车辆
        public int AddCar(CarInfo c)
        {
            string AddCar = $"insert into CarInfo values('{c.Image}',{c.bid},'{c.CarName},{c.Years},{c.cid},'{c.CC}','{c.AMT}',{c.Price},{c.Address}')";
            return DBHelper.ExecuteNonQuery(AddCar);
        }


        

    }
}
