﻿using AutoMapper;
using Identity.Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IMapper mapper;

        public UserController(SignInManager<IdentityUser> signInManager, IMapper mapper)
        {
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<AuthenticateRequest> Registation(AuthenticateRequest model)
        {
            var user = mapper.Map<IdentityUser>(model);
            var resut = await signInManager.UserManager.CreateAsync(user, model.Password);
            await signInManager.UserManager.AddToRoleAsync(user, "Visitor");

            return model;
        }
    }
}
