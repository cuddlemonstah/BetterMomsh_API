using Application.Common.Exceptions;
using Application.Common.RequestResponse;
using Application.Services.Users.Request;
using Application.Services.Users.Validators;
using AutoMapper;
using Domain.Entities.Identity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users.Commands
{
    public class CreateUser
    {
        public class Command : IRequest<Result<User>> {
            public UserRequest UserReq { get; set; } = default!;
        }

        public class CommandValidator : AbstractValidator<Command> { 
            public CommandValidator() {
                RuleFor(x => x.UserReq).SetValidator(new UserValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<User>> { 
            private readonly UserManager<User> _userManager;
            private readonly IMapper _mapper;
            public Handler(UserManager<User> userManager, IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<Result<User>> Handle(Command request, CancellationToken cancellationToken) {

                var user = _mapper.Map<User>(request.UserReq);
                var userEmailExist = await _userManager.FindByEmailAsync(request.UserReq.Email);
                var userUserNameExist = await _userManager.FindByEmailAsync(request.UserReq.UserName);

                if (userEmailExist is not null) return Result<User>.Failure("Email already exist");
                if (userUserNameExist is not null) return Result<User>.Failure("Username Already Exist");

                var response = await _userManager.CreateAsync(user, request.UserReq.Password);

                if (!response.Succeeded && response.Errors.Count() > 0) {
                    return Result<User>.ErrorResult("Failed", response.Errors
                        .Select(x => new Error("400", x.Code, x.Description))
                        .ToList()
                        .AsReadOnly());
                }

                if (!response.Succeeded) {
                    return Result<User>.Failure("Failed To Create User");
                }

                return Result<User>.Success(user);
            }
        }
    }
}
