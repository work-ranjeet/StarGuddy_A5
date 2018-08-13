using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StarGuddy.Core.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;

namespace StarGuddy
{
    public class Startup
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option =>
            {
                option.AllowEmptyInputInBodyModelBinding = true;
            });

            services.AddAutoMapper();
            services.AddCors(options => options.AddPolicy("Cors", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(jwtBearerCnfg =>
            {
                var signingKey =

                jwtBearerCnfg.RequireHttpsMetadata = false;
                jwtBearerCnfg.SaveToken = true;
                jwtBearerCnfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration.GetAppSettingValue(AppSettings.JwtIssuer),
                    ValidAudience = Configuration.GetAppSettingValue(AppSettings.JwtAudience),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetAppSettingValue(AppSettings.JwtSecret)))
                };

                //jwtBearerCnfg.Events = new JwtBearerEvents
                //{
                //    OnAuthenticationFailed = context =>
                //    {
                //        Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                //        return Task.CompletedTask;
                //    },
                //    OnTokenValidated = context =>
                //    {
                //        Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                //        return Task.CompletedTask;
                //    }
                //};
            });

            services.AddAuthorization(authOption =>
            {
                //options.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                //    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                //    .RequireAuthenticatedUser().Build());

                authOption.AddPolicy("Member", policy =>
                {
                    policy.RequireClaim(JwtRegisteredClaimNames.Sid);
                    policy.RequireClaim(JwtRegisteredClaimNames.Email);
                });
            });           

            //// Dependency Injection
            Api.Injection.Inject(services, Configuration);
        }

        /// <summary>
        /// Configures the specified application. This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The environment.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseCors("Cors");

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
