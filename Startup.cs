using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImoStatemiddleware.BussinessLogic.Interfaces;
using ImoStatemiddleware.BussinessLogic.Repositories;
using ImoStatemiddleware.Data.ProductModel;
using ImoStatemiddleware.Utility;
using ImoStatemiddleware.Utility.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ImoStatemiddleware
{
    public class Startup
    {
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            Configuration = new ConfigurationBuilder()
              .SetBasePath(hostingEnvironment.ContentRootPath)
              .AddJsonFile("appsettings.json")
              .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AuthenticationUtilityDBContext.ConnectionString = Configuration.GetConnectionString("AuthenticationNetCoreEF");

            //Server configuration
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IProductRepo<ProductCode>, ProductCodeRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "FCMB Imo State Middleware", Version = "v1" });
                c.AddSecurityDefinition("Basic", new BasicAuthScheme { Description = "Basic authentication" });
                c.DocumentFilter<BasicAuthFilter>();
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

            //app.UseHttpsRedirection();
            app.UseSwagger(c =>
            {
                //Change the path of the end point , should also update UI middle ware for this change                
                c.RouteTemplate = "{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/v1/swagger.json", "");
            });
            app.UseMvc();
        }
    }
}
