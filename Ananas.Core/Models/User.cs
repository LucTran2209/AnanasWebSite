using System;
using System.Collections.Generic;
namespace Ananas.Core.Models;


public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? CoverEmail { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
