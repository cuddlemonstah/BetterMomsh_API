using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserRoles.Responses
{
    public class UserRoleResponse
    {
        public string UserId { get; set; } = string.Empty;  
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public IList<string>? Roles {  get; set; } 
    }
}
