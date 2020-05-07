using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace CarAPI.Controllers
{
    [Route("CarY")]  
    [Produces("application/json")]
    [EnableCors("first")]
    [ApiController]
    public class YcxCarController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public YcxCarController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = "Data Source=.;Initial Catalog=Pcr;Integrated Security=True";

        }
        /// <summary>
        /// 获取已启用的 汽车信息
        /// </summary>
        /// <returns></returns>
        [HttpGet(template:"getcar")]
        public ActionResult<IEnumerable<CarInfo>> GetListOfAuthors()
        {
            var authors = new List<CarInfo>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from CarType c join CarInfo i on c.CarTypeID=i.cid join CarBrand b on i.bid = b.CarBrandID join AllCars a on i.CarInfoID = a.CarInfoid join Va v on a.Vaid = v.VID join CarType c2 on v.cid = c2.CarTypeID join CarBrand b2 on v.bid = b2.CarBrandID where v.Vstate = 1 ";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    authors.Add(HelperOper.ADONetToClass<CarInfo>(reader));
                }
            }

            return Ok(authors);
        }

        [HttpPost(template:"selectcar")]
        public ActionResult<IEnumerable<CarInfo>> SelectCarOper(string carname ,int carP,int carTyep)
        {
            var authors = new List<CarInfo>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = $"select * from CarType c join CarInfo i on c.CarTypeID=i.cid join CarBrand b on i.bid = b.CarBrandID join AllCars a on i.CarInfoID = a.CarInfoid join Va v on a.Vaid = v.VID join CarType c2 on v.cid = c2.CarTypeID join CarBrand b2 on v.bid = b2.CarBrandID where v.Vstate = 1 and i.CarName like '%{carname}%' or c.CarTypeID={carP} or b.CarBrandID={carTyep}";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    authors.Add(HelperOper.ADONetToClass<CarInfo>(reader));
                }
            }

            return Ok(authors);
        }
        [HttpGet(template:("brandsee"))]
        public ActionResult<IEnumerable<CarBrand>> ToBrand()
        {
            var authors = new List<CarBrand>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from CarBrand";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    authors.Add(HelperOper.ADONetToClass<CarBrand>(reader));
                }
            }

            return Ok(authors);
        }
        [HttpGet(template:("typesee"))]
        public ActionResult<IEnumerable<CarType>> ToType()
        {
            var authors = new List<CarType>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from cartype";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    authors.Add(HelperOper.ADONetToClass<CarType>(reader));
                }
            }

            return Ok(authors);
        }




    }

    public class HelperOper
    {
        public static T ADONetToClass<T>(SqlDataReader reader) where T : new()
        {
            var entity = new T();
            var type = typeof(T);
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == "ID")
                {
                    property.SetValue(entity, Guid.Parse(reader[property.Name].ToString()));
                }
                else
                {
                    property.SetValue(entity, Convert.ChangeType(reader[property.Name], property.PropertyType));
                }
            }

            return entity;
        }

    }
}