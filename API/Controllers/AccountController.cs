using API.Services.Interfaces;
using Application.Services.Accounts.Requests;
using Application.Services.Accounts.Response;
using AutoMapper;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ApiBaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenService tokenService,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            var user = await _userManager.Users
                                .FirstOrDefaultAsync(x => x.Email.Equals(request.Email));
            if (user == null)
            {
                return Unauthorized("Invalid Email or Password");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(await CreateAuthResponse(user, roles));
            }
            return Unauthorized("Invalid Email and Password");
        }

        /*[AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> Register(UserRequest request) {
            return HandleResult(await Mediator.Send(new CreateUser.Command { UserReq = request}));
        } */

        [HttpGet("me")]
        [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCurrentUser()
        {
            var user = await _userManager.Users
                            .FirstOrDefaultAsync(x => x.Email.Equals(User.FindFirstValue(ClaimTypes.Email)));

            if (user == null) return Unauthorized("Invalid email or password");

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(await CreateAuthResponse(user, roles));
        }
        private async Task<AuthResponse> CreateAuthResponse(User user, IList<string>? roles)
        {

            return new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = roles,
                AccessToken = await _tokenService.CreateToken(user)
            };
        }
    }
}
