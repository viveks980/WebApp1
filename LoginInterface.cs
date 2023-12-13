using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1
{
    public interface LoginInterface
    {
         loginmodel Login(loginmodel login);
         loginmodel adduser(loginmodel objmodel);
         List<loginmodel> getuserbyid(int Id);

    }
}
