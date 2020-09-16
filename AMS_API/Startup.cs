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
using System.Linq;
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

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            /*
             * Because EF Core will automatically fix-up navigation properties, 
             * you can end up with cycles in your object graph. 
             * For example, loading a blog and its related posts will result in a blog object that 
             * references a collection of posts.Each of those posts will have a reference back to the blog.
             * Some serialization frameworks do not allow such cycles.
             * For example, Json.NET will throw the following exception if a cycle is encountered.
             * Newtonsoft.Json.JsonSerializationException: Self referencing loop detected for property 'Blog' 
             * with type 'MyApplication.Models.Blog'.
             * https://docs.microsoft.com/en-us/ef/core/querying/related-data
           */

            services
               .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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

            //services.Configure<ApiBehaviorOptions>((options) =>
            //{
            //    options.InvalidModelStateResponseFactory = ((actionContext) =>
            //    {
            //        ValidationProblemDetails error = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0)
            //        .Select(e => new ValidationProblemDetails(actionContext.ModelState)).FirstOrDefault();

            //        return new BadRequestObjectResult(error);
            //    });
            // });
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

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("Content-Disposition"));
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
