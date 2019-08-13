using System.Data.Common;
using System.Data;
using System;
using MySql.Data;
using Dapper;
using System.Linq;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;        
using System.Collections.Generic;
using System.Web;
using api.Models;
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController 
    {
        DapperClass dap=new DapperClass();
       // private readonly string ConnectionString=@"Data Source=139.59.43.76;Initial Catalog=TestDb;user=mahadev;password=mDev@1260!op;";
        [HttpGet]
        public string Getdata(){
            try{
            using (var con=new MySqlConnection(dap.dapperConnection())){
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
                using(var con=new MySqlConnection(dap.dapperConnection())){
                    con.Query("insert into Student_details values("+stu.Sid+",'"+stu.Name+"','"+stu.Address+"','"+stu.City+"','"+stu.Gen+"')");
                    return "successfuly created";
                }
            }
            catch(Exception ex){
                return ex.Message;
            }
        }
        [HttpGet]
        public int sptest(){
            using(var con=new MySqlConnection(dap.dapperConnection())){
                DynamicParameters dnp=new DynamicParameters();
                dnp.Add("gen","male");
                dnp.Add("@totalemp",dbType: DbType.Int32,direction:ParameterDirection.Output);
                con.Execute("sptest",dnp,commandType:CommandType.StoredProcedure);
                int totalcnt = dnp.Get<int>("@totalemp");
                return totalcnt;
            }
        }
        
        [HttpGet]
        public string spInsert(){
            using(var con=new MySqlConnection(dap.dapperConnection())){
                DynamicParameters dnp=new DynamicParameters();
                dnp.Add("empid",7);
                dnp.Add("_name","Arup Sarkar");
                dnp.Add("gen","male");
                try{
                con.Execute("spInsert",dnp,commandType:CommandType.StoredProcedure);
                return "success !";
                }
                catch(Exception ex){
                    return ex.Message;
                }

            }
        }
    }
}