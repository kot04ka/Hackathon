using System.ComponentModel.DataAnnotations;

namespace Hackathon.EF_Core.Dbo
{
    public class UserDbo
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

    }
}
