using System.Net.Cache;
using System;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Linq;
using api.Models;
using api.layer;
using System.Linq;
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InjectionController
    {
        Bll ob=new Bll();
        [HttpPost]
        public string save([FromBody] EmpModel model){
            //dynamic data=JsonConvert.DeserializeObject(content);
            return ob.SaveD(model.name,model.address,model.salary,model.city,model.gender,model.department,model.company);

        }
    }
}