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
        string Conn = "Data Source =.; Initial Catalog = Pcr;Integrated Security = True";
        //车辆预定信息
        public List<Orders> OrderShow()
        {
            using (SqlConnection conn = new SqlConnection(Conn))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Orders";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                var mess = new List<MessInfo>();
                foreach (DataRow i in dt.Rows)
                {
                    var m = new MessInfo();
                    m.ID = Convert.ToInt32(i["ID"].ToString());
                    m.UserId = Convert.ToInt32(i["UserId"].ToString());
                    m.Content = i["Content"].ToString();
                    m.Time = Convert.ToDateTime(i["Time"].ToString());
                    m.ZT = Convert.ToBoolean(i["ZT"].ToString());
                    m.UserName = i["UserName"].ToString();
                    mess.Add(m);
                }
                return mess;
            }
        }
    }
}
