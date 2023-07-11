using System.ComponentModel.DataAnnotations;

namespace EduHome2.UI.ViewModels.AuthViewModels;

public class LoginVM
{
    [Required]
    public string Username { get; set; } = null!;
    [Required, DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    public bool RememberMe { get; set; }
}
