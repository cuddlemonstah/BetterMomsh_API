using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Roles.Requests
{
    public class RoleRequest
    {
        public uint? Id { get; set; }
        public string Role { get; set; } = default!;

    }
}
