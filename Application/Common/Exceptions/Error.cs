using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class Error {
        public string Code { get; }
        public string Description { get; set; }
        public string Details { get; set; }
        public Error(string details) : this(null!, null!, details) { 
        
        }

        public Error(string code, string description, string details) { 
            Code = code;
            Description = description;
            Details = details;
        }
    }
}
