using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class AdminsBLL
    {
        AdminsDAL dal = new AdminsDAL();

        //车辆类型
        public List<CarType> TypeShow()
        {
            return dal.TypeShow();
        }

        //车辆品牌
        public List<CarBrand> BrandShow()
        {
            return dal.BrandShow();
        }

        //车辆预定信息
        public List<Orders> OrderShow()
        {
            return dal.OrderShow();
        }

        //用户挂靠的车辆信息
        public List<Va> VaShow()
        {
            return dal.VaShow();
        }

        //新增车辆
        public int AddCarInfo(CarInfo c)
        {
            return dal.AddCarInfo(c);
        }

        //查看故障报修原因
        public Breakdown GetBreakdown(int id)
        {
            return dal.GetBreakdown(id);
        }

        //审批
        public int UptVa(Va v)
        {
            return dal.UptVa(v);
        }

        //修改故障状态为：报修通过
        public int UptOrdersAgree(Orders o)
        {
            return dal.UptOrdersAgree(o);
        }

        //修改故障状态：有待商议
        public int UptOrdersDisAgree(Orders o)
        {
            return dal.UptOrdersDisAgree(o);
        }
    }
}
