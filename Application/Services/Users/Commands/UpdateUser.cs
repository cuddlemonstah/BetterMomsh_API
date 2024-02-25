using Application.Common.RequestResponse;
using Application.Services.Users.Request;
using Application.Services.Users.Response;
using Application.Services.Users.Validators;
using AutoMapper;
using Domain.Entities.Identity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Users.Commands
{
    public class UpdateUser
    {
        public class Command : IRequest<Result<User>> {
            public UserRequest UserRequest { get; set; } = default!;
            public bool IsWithCredsChecking { get; set; } = true;
        }

        public class CommandValidator : AbstractValidator<Command> { 
            public CommandValidator() {
                RuleFor(x => x.UserRequest).SetValidator(new UserValidator());
            }
        }

        public class Handler : IRequestHandler<Command ,Result<User>> {
            private readonly DataContext _context;
            private readonly UserManager<User> _userManager;
            private readonly IMapper _mapper;
            public Handler(DataContext context, UserManager<User> userManager, IMapper mapper)
            {
                _context = context;
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<Result<User>> Handle(Command request, CancellationToken cancellationToken) {
                var user = await _userManager.FindByIdAsync(request.UserRequest.Id?.ToString());

                if (user == null) return Result<User>.Failure("User not found");
                if (request.IsWithCredsChecking) {
                    if (user.NormalizedEmail!.Equals(request.UserRequest.Email.ToUpperInvariant())) { 
                    }
                }

                return Result<User>.Success(user);
            }
        }
    }
}
