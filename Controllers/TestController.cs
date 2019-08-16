using System.Net.Cache;
using System;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Linq;
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController
    {
        private readonly string constring=@"Data Source=localhost;Initial Catalog=arupdb;user=arup;password=password;";
        [HttpGet]
        public string Testdata(){
            using(var con=new MySqlConnection(constring)){
                var data=con.Query("select * from test").ToList();
                return JsonConvert.SerializeObject(data);
            }
        }
    }
}