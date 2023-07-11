using Microsoft.AspNetCore.Identity;

namespace EduHome2.Core.Entities;

public class AppUser:IdentityUser
{
    public string? Fullname { get; set; }
}
