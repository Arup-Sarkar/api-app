using System.Net.Cache;
using System;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Linq;
using api.Models;
namespace api.layer
{
    public class Bll
    {
        Dal ob=new Dal();
        public string SaveD(string nm,string adr,string sal,string ct,string gen,string dept,string cmp){
            string sqlquery="insert into employee(`name`,`address`,`salary`,`city`,`gender`,`department`,`company`) values('"+nm+"','"+adr+"','"+sal+"','"+ct+"','"+gen+"','"+dept+"','"+cmp+"')";
            return ob.SaveData(sqlquery);
            
        }
        
    }
}