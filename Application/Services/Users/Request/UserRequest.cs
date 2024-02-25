using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users.Request
{
    public class UserRequest
    {
        public string? Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName {  get; set; } = string.Empty;

        [EmailAddress]
        public string Email {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
