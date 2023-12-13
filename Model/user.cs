using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class user
    {
        public int Id { get; set; }
        public string ? Name { get; set;}
        public string? department { get; set; }
        public DateTime @joindate { get; set; }

        public int rollno { get; set; }
        public Boolean status { get; set; }
    }
}
