using System.ComponentModel.DataAnnotations;
using System.Data;
using ServerMVC.Infrastructure.Enum;

namespace ServerMVC.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
