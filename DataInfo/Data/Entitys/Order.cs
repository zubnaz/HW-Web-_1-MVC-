using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInfo.Data.Entitys
{
    public class Order
    {
        //public int Id { get; set; }
        [Key]
        public int AutoId { get; set; }
        public Auto Auto { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
