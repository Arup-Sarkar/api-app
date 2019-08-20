using System;
using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
namespace api.layer
{
  public class Dal
  {
    private readonly string constring=@"Data Source=localhost;Initial Catalog=arupdb;user=arup;password=password;";
    public string  SaveData(string sqlquery)
    {
        try{
            using(var con=new MySqlConnection(constring)){
                con.Query(sqlquery);
                //var  ide = con.ExecuteScalar<int>("select LAST_INSERT_ID();");
                return con.ExecuteScalar<int>("select LAST_INSERT_ID();").ToString();
            }
        }
        catch(Exception ex){
            return ex.Message;
        }
    }
  }
}