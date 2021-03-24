using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        [HttpGet]        
        public List<string> GetAll()
        {
            return new List<string>() { "Hello", "World" };
        }
    }
}
