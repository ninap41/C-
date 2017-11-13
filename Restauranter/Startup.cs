using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//

using Restauranter.Models;
using MySQL.Data.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;


using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore; //entity


namespace Restauranter
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSession();
            services.AddDbContext<RestauranterContext>(options => options.UseNpgsql(Configuration["DBInfo:ConnectionString"]));
            // System.Data.Entity.Database.SetInitializer<MyPgSqlContext>(new MyDbContextDropCreateDatabaseAlways());
            // services.AddDbContext<RestauranterContext>(options => options.UseMySQL((Configuration["DBInfo:ConnectionString"]))); //change depending on project

            // services.Configure<MySqlOptions>(Configuration.GetSection("DBInfo"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
        }
        public IConfiguration Configuration { get; private set; }
 
        public Startup(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables();
        Configuration = builder.Build();
        }

    }
}
