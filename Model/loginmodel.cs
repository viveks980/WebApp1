using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class loginmodel
    {
        internal int Id;
        public string userName { get; set; }

        public string password { get; set; }
        public Boolean status { get; set; }
        public string Message { get; set; }
        public string Decryped_password { get; set; }
    }
}
