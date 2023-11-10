using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Domain.Models
{
    public class Point
    {
        public int Id { get; set; }
        List<PointAttribute> Attributes { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
