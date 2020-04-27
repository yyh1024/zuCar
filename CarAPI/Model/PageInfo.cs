using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //分页实体类
    public class PageInfo
    {
        public List<Va> Vas { get; set; }   //挂靠表
        public List<Orders> Orders { get; set; }  //订单表
        public int totalCount { get; set; }  //总记录数
        public int totalPage { get; set; }   //总页数
        public int currentPage { get; set; } //当前页
        public int pageSize { get; set; }  //每页记录数
    }
}
