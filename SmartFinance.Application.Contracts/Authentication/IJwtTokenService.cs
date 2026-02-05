using SmartFinance.Application.Contracts.Authentication.Dto;
using SmartFinance.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Contracts.Authentication
{
    public interface IJwtTokenService
    {
        AuthResponseDto GenerateToken(User user, List<string> roles);
    }
}
