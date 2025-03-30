using System;
using System.Collections.Generic;

namespace DAL.Enities;

public partial class UserAccount
{
    public int UserId { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? Role { get; set; }

    public DateTime? CreatedDate { get; set; }
}
