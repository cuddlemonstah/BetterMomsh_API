using API.Services;
using API.Services.Interfaces;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistance;
using System.Text;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration iconfig)
        {

            Configuration = iconfig;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //AppSettings Configuration
            //services.Configure<>
            services.AddPersistenceServices(Configuration);

            services.AddRazorPages();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(config =>
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
                config.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } };
                config.AddSecurityRequirement(securityRequirement);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Cors", policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders("WWW-Authenticate", "Pagination")
                    .WithOrigins("http://localhost:5114");

                });
            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {

                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(180);
            });

            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            }).
                AddRoles<Role>().AddRoleManager<RoleManager<Role>>().
                AddSignInManager<SignInManager<User>>().AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AccessTokenKey"]!));

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

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            });
            services.AddScoped<ITokenService, ITokenService>();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc(option => option.EnableEndpointRouting = false);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Cors");

            app.UseStaticFiles();
            app.UseSession();

            app.UseHttpsRedirection();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });


        }
    }
}
