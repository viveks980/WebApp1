using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1
{
    
   public interface Interface
    {
        ResponseModel StaticMailSend();
        ResponseModel StaticMailSendTemp(String name, string EmpId, string dob, String mbl);
    }
}
