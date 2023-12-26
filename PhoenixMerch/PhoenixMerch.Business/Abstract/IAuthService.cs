using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoenixMerch.Entities.Concrete;
using PhoenixMerch.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.Business.Abstract
{
    public interface IAuthService
    {
        UserManager<AppUser> _userManager { get; set; }
        RoleManager<AppRole> _roleManager { get; set; }
        SignInManager<AppUser> _signInManager { get; set; }
        IMapper _mapper { get; set; }

        public async Task<AppUser> GetUser(string email)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<AppUser> GetUserByUserName(string userName)
        {
            return await _userManager.Users.FirstOrDefaultAsync(user => user.UserName == userName);
        }

        public async Task<SignInResult> Login(LoginDto loginDto)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);

            return user == null ? new SignInResult() : await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> AddRoleToUser(AppUser user, string role)
        {
            AppRole rol = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Name == role);
            if (rol is null)
            {
                await _roleManager.CreateAsync(new AppRole() { Name = role, NormalizedName = role.ToUpper() });
            }
            return await _userManager.AddToRoleAsync(user, role);
        }
        public async Task<IdentityResult> Register(RegisterDto registerDto)
        {
            AppUser user = _mapper.Map<AppUser>(registerDto);
            IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                await AddRoleToUser(user, "User");
            }
            return result;
        }

        public async Task<IdentityResult> CustomerRegister(CustomerRegisterDto customerRegisterDto)
        {
            var user = new AppUser { UserName = customerRegisterDto.UserName, Email = customerRegisterDto.Email };
            var customer = new Customer { FirstName = customerRegisterDto.FirstName, LastName = customerRegisterDto.LastName, PhoneNumber = customerRegisterDto.PhoneNumber, Status = true };
            user.Customer = customer;
            var result = await _userManager.CreateAsync(user, customerRegisterDto.Password);

            if (result.Succeeded)
            {
                await AddRoleToUser(user, "Customer");
            }
            return result;
        }

        public AppUser GetUserByEmail(string email)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Email == email);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public async Task<string> GetRoleByUserName(string userName)
        {
            var user = await GetUserByUserName(userName);
            var roleList = (await _userManager.GetRolesAsync(user));
            if (roleList.Count > 0)
            {
                return roleList[0];
            }
            return null;
        }


    }
}
