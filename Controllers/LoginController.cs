using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        LoginClass lcs = new LoginClass();
        [HttpPost, Route("LoginApp")]
        public loginmodel Login([FromForm] loginmodel login)
        {
            loginmodel res = lcs.Login(login);
            
            return res;
            
        }
        [HttpPost, Route("adduser")]
        public loginmodel adduser([FromForm] loginmodel objmodel)
        {
            
            var k = lcs.adduser(objmodel);
            return k;
        }

        [HttpGet, Route("getuserbyid")]

        public List<loginmodel> getstudentbyid(int Id)

        {
            
            List<loginmodel> res = lcs.getuserbyid(Id);
            return res;

        }
    }
}
