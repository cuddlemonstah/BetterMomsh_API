using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Accounts.Response
{
    public class AuthResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName {  get; set; } = default!;
        public string LastName { get; set; } = string.Empty;
        public string AccessToken { get; set; } = default!;
        public IList<string>? Roles { get; set; }

    }
}
