using Microsoft.EntityFrameworkCore;
using SmartFinance.Application.Contracts.Authentication;
using SmartFinance.Application.Contracts.Authentication.Dto;
using SmartFinance.Domain.Customer.CustomerAggregate;
using SmartFinance.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Authentication
{
    public class AuthenticationService : IAuthService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMerchantRepository _merchantRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IPasswordHasher _hash;
        private readonly IJwtTokenService _jwtTokenService;
        public AuthenticationService(IUserRepository userRepository, 
                                     IUserRoleRepository userRoleRepository,
                                     ICustomerRepository customerRepository,
                                     IMerchantRepository merchantRepository,
                                     IPasswordHasher hash, 
                                     IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _customerRepository = customerRepository;
            _merchantRepository = merchantRepository;
            _hash = hash;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.FindByExpressionAsync(n => n.UserName == request.UserName);

            if(user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            if (_hash.VerifyPassword(user.PasswordHash, request.Password))
            {
                var roles = await _userRoleRepository.GetRolesOfUser(userId: user.Id);

                var token = _jwtTokenService.GenerateToken(user, roles);

                return new AuthResponseDto
                {
                    AccessToken = token.AccessToken,
                    ExpiresAt = token.ExpiresAt
                };
            }
            else
                throw new InvalidOperationException("Invalid credentials");
        }

        public async Task RegisterAsync(RegisterRequestDto request)
        {
            if (await _userRepository.IsAnyAsync(n => n.UserName == request.UserName))
            {
                throw new InvalidOperationException("User already existed");
            }

            var obj = new object(); ;

            if (request.UserType == "C")
            {
                
            }

            var user = User.Create("", request.UserName, request.EmailAddress, request.PhoneNumber, request.UserType, _hash.HashPassword(request.Password));

            await _userRepository.CreateAsync(user);
        }
    }
}
