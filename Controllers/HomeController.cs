using System;
using MySql.Data;
using Dapper;
using System.Linq;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;        
using System.Collections.Generic;
using api.Models;
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController 
    {
        private readonly string ConnectionString=@"Data Source=139.59.43.76;Initial Catalog=TestDb;user=mahadev;password=mDev@1260!op;";
        [HttpGet]
        public string Getdata(){
            try{
            using (var con=new MySqlConnection(ConnectionString)){
                var res=con.Query("select * from Student_details").ToList();
                return JsonConvert.SerializeObject(res);
            }
            }
            catch(Exception ex){
                return ex.Message;
            }
        }

        [HttpPost]
        public string InsertStudents(StudentModel stu){
            try{
                using(var con=new MySqlConnection(ConnectionString)){
                    con.Query("insert into Student_details values("+stu.Sid+",'"+stu.Name+"','"+stu.Address+"','"+stu.City+"','"+stu.Gen+"')");
                    return "successfuly created";
                }
            }
            catch(Exception ex){
                return ex.Message;
            }
        }
        
    }
}