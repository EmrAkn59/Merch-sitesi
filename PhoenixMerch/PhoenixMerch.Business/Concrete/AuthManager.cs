using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PhoenixMerch.Business.Abstract;
using PhoenixMerch.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixMerch.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        UserManager<AppUser> _userManager;
        RoleManager<AppRole> _roleManager;
        SignInManager<AppUser> _signInManager;
        IMapper _mapper;

        public AuthManager(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        UserManager<AppUser> IAuthService._userManager { get => _userManager; set => value = _userManager; }
        RoleManager<AppRole> IAuthService._roleManager { get => _roleManager; set => value = _roleManager; }
        SignInManager<AppUser> IAuthService._signInManager { get => _signInManager; set => value = _signInManager; }
        IMapper IAuthService._mapper { get => _mapper; set => value = _mapper; }
    }
}
