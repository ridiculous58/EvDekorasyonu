using EvDekorasyonu.Domain.Dtos;
using Microsoft.AspNetCore.Identity;

namespace EvDekorasyonu.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<IdentityUser> Login(LoginDto loginDto);
        Task<IdentityUser> Register(RegisterDto registerDto, IEnumerable<string> roles);
        Task Logout();
    }
}
