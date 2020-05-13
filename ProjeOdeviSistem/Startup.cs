using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjeOdeviSistem.Helper;
using ProjeOdeviSistem.Helpers;

namespace ProjeOdeviSistem
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

            services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", r =>
                {
                    r.Cookie.Name = "LoginAuth";
                    r.LoginPath = "/Login";
                });


            string mongoConnectionString = this.Configuration.GetConnectionString("MongoConnectionString");
            services.AddTransient(s => new helperUser(mongoConnectionString, "userCollection", "Users"));
            services.AddTransient(s => new helperCategories(mongoConnectionString, "userCollection", "Categories"));
            services.AddTransient(s => new helperProducts(mongoConnectionString, "userCollection", "Products"));
            services.AddTransient(s => new helperOrders(mongoConnectionString, "userCollection", "Orders"));
            services.AddTransient(s => new helperOrderDetails(mongoConnectionString, "userCollection", "OrderDetails"));
            services.AddTransient(s => new helperCart(mongoConnectionString, "userCollection", "Cart"));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
