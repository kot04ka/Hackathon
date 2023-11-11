using System.ComponentModel.DataAnnotations;

namespace Hackathon.EF_Core.Dbo
{
    public class PointDbo
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<PointAttributeDbo> Attributes { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
