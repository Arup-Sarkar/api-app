using Dapper;
using System;
using MySql.Data.MySqlClient;
namespace api.Models
{
    public class DapperClass
    {
        public String dapperConnection(){
            string st= @"Data Source=139.59.43.76;Initial Catalog=TestDb;user=mahadev;password=mDev@1260!op;";
            return st;
        }
    }
}