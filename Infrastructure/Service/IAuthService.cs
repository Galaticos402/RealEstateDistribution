using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IAuthService
    {
        Task<string> Authorize(string email, string password);
        int? GetCurrentUserId(string authHeader);

        string? GetCurrentUserRole(string authHeader);
    }
}
