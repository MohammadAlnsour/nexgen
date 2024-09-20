using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Application.Contracts.DTOs
{
    public class AuthUserResponseDTO
    {
        public bool IsAuthorized { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
