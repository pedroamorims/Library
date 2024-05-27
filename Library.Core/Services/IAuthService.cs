using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
    }
}
