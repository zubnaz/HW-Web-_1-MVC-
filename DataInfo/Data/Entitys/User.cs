using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInfo.Data.Entitys
{
    public class User : IdentityUser
    {
        public DateTime Birthday { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
