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
