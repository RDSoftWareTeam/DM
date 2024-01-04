using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.entity
{
    class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string userpwd { get; set; }
        public string realname { get; set; }
        public string photo { get; set; }
        public int idt_role { get; set; }
    }
}
