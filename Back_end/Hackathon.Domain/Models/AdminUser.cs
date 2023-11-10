using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Domain.Models
{
    public class AdminUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public sbyte UserPassword { get; set; }
    }
}
