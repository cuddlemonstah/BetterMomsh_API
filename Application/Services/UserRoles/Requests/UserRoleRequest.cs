using Application.Services.Users.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserRoles.Requests
{
    public class UserRoleRequest
    {
        public UserRequest User { get; set; } = default!;
        public uint RoleId { get; set; }
        public uint OwnerId { get; set; }
    }
}
