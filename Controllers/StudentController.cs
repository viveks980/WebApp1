using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;  
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dal;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpPost, Route("addstudent")]
        public ResponseModel addstudent([FromForm]user objmodel)
         {
            student_class s = new student_class();
            var k = s.addstudent(objmodel);
            return k;
        }


        [HttpPost, Route("deletestudent")]
        public ResponseModel deletestudent([FromForm] int Id)
        {
            student_class s = new student_class();
            var k = s.deletestudent(Id);
            return k;
        }

        [HttpPost, Route("updatestudent")]
        public ResponseModel updatestudent([FromForm] user objmodel)
        {
            student_class stu = new student_class();
            var s = stu.updatestudent(objmodel);
            return s;
        }

       

        [HttpGet, Route("getstudentdetails")]

        public List<user> getstudentdetails()

        {
            student_class stu = new student_class();
            List<user> res = stu.getstudentdetails();
            return res;

        }
        [HttpGet, Route("getstudentbyid")]

        public List<user> getstudentbyid(int Id)

        {
            student_class stu = new student_class();
            List<user> res = stu.getstudentbyid(Id);
            return res;

        }

        [HttpPost, Route("create")]
        public IActionResult create([FromBody] user user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }
    }
}
