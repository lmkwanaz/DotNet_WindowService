using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Data.Entity
{
    public class Student
    {
        public virtual int UserID {get; set;}
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual bool Active { get; set; }
    }
}
