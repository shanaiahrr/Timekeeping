using System.Data.SqlClient;
using Domain;
using Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebAPI.Utils;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var settings = Configuration.GetSection("TimeTrackingSettings").Get<TimeTrackingSettings>();
            services.AddSingleton(settings);
           
            services.AddDbContext<TimeKeepingDBContext>(options =>
            {
                var connectionString = Configuration["Settings:ConnectionString"];
                var password = Configuration["DbPassword"];
                var builder = new SqlConnectionStringBuilder(connectionString);
                builder.Password = password;
                var connection = builder.ConnectionString;
                options.UseSqlServer(connection);
            });
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IRoleRepository, RolesRepository>();
            services.AddTransient<IRightRepository, RightsRepository>();
            services.AddTransient<ITypeofRightRepository, TypeofRightRepository>();
            services.AddTransient<IRoleRightRepository, RoleRightsRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IShiftRepository, ShiftRepository>();
            services.AddTransient<IActivityTypeRepository, ActivityTypeRepository>();
            services.AddTransient<IDayRepository, DaysRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(config => {
                config.AddPolicy("TimeTrackingAngular", policy => {
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                    policy.AllowAnyOrigin();
                    policy.AllowCredentials();

                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "TimeTracking API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimeTracking API v1");
            });
            //app.UseHttpsRedirection();
            app.UseCors("TimeTrackingAngular");

            app.UseMvc();
        }
    }
}
