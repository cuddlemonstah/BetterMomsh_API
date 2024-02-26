using API.Services.Interfaces;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Persistance;
using API.Services;

namespace API
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer Scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                options.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } };
                options.AddSecurityRequirement(securityRequirement);
                options.DescribeAllParametersInCamelCase();
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Cors", policy =>
                {
                    policy.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithExposedHeaders("WWW-Authenticate", "Pagination")
                        .WithOrigins(
                            "http://localhost:3000");
                });
            });

            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["AccessTokenKey"]!));

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;

                            if (!string.IsNullOrEmpty(accessToken) &&
                                (path.StartsWithSegments("/hubs") || path.StartsWithSegments("/uploads")))
                            {
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

            // required for accessing http context in the custom middle wares
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpClient();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}