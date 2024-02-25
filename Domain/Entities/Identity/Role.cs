﻿
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{
    public class Role : IdentityRole<string>
    {
        public virtual ICollection<UserRole> Users { get; set; } = default!;
    }
}
