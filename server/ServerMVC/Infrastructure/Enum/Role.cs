using System.ComponentModel.DataAnnotations;

namespace ServerMVC.Infrastructure.Enum
{
    public enum Role
    {
        [Display(Name = "Пользователь")]
        User = 0,
        [Display(Name = "Админ")]
        Admin = 1,
    }
}
