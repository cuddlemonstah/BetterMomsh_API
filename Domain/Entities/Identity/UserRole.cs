﻿using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual User User { get; set; } = default!;
        public virtual Role Role { get; set; } = default!;
    }
}
