using AutoMapper;
using EvDekorasyonu.Application.Interfaces;
using EvDekorasyonu.Domain.Dtos;
using Microsoft.AspNetCore.Identity;

namespace EvDekorasyonu.Persistence.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;

        public IdentityService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<IdentityUser> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return null;

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, true);

            if (!signInResult.Succeeded)
                throw new Exception("Email or password is incorrect");

            await _signInManager.SignInAsync(user, loginDto.RememberMe);

            return user;
        }

        public async Task<IdentityUser> Register(RegisterDto registerDto, IEnumerable<string> roles)
        {
            var identityUser = _mapper.Map<IdentityUser>(registerDto);

            var identityResult = await _userManager.CreateAsync(identityUser, registerDto.Password);

            if (!identityResult.Succeeded)
                throw new Exception(string.Join(" ", identityResult.Errors.Select(x => $"{nameof(x.Code)} : {x.Code}, {nameof(x.Description)} : {x.Description}")));

            await _userManager.AddToRolesAsync(identityUser, roles);

            await _signInManager.SignInAsync(identityUser, registerDto.RememberMe);

            return identityUser;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
