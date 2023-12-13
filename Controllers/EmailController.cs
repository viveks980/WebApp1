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
    public class EmailController : ControllerBase
    {
       
            EmailClass em = new EmailClass();

            [HttpPost, Route("StaticMailSend")]
            public ResponseModel StaticMailSend()
            {
                ResponseModel res = em.StaticMailSend();
                return res;
            }

        [HttpPost, Route("StaticMailSendTemp")]
        public ResponseModel StaticMailSendTemp(String name,String EmpId,String dob,String mbl)
          {
            ResponseModel res = em.StaticMailSendTemp(name,EmpId,dob,mbl);
            return res;
         }
    }
    }

