using API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Service_Layer.Interface;
using Service_Layer.Services;
using System.Net;
using System.Text;

namespace AMS_API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            ConnectionString = Configuration.GetConnectionString("DefaultConnection");

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DataContext>(x => x.UseSqlServer(ConnectionString));

            services.AddCors();

            //services.AddHttpContextAccessor();

            services.AddAutoMapper(typeof(IBusinessService));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddScoped<IBusinessService, BusinessService>();

            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IMenuService, MenuService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IGroupService, GroupService>();

            services.AddScoped<IAccountTypeService, AccountTypeService>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<IRelationshipService, RelationshipService>();

            services.AddScoped<IUserActivityService, UserActivityService>();

            services.AddScoped<IReportService, ReportService>();

            services.AddScoped<CustomActionFilter>();



            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),

                    ValidateIssuer = false,

                    ValidateAudience = false

                };

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseExceptionHandler(builder => builder.Run(
                    async context =>
                    {

                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();

                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    }
                ));
            }
            else
            {
                app.UseExceptionHandler(builder => builder.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature>();

                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);

                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    }
                ));
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Fallback", action = "Index" }
                );
            });
        }
    }
}
