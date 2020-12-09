using GroceryStore2.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GroceryStore2 {
  public class Startup {
    public Startup (IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices (IServiceCollection services) {
      services.AddDbContext<AppDbContext> (options =>
        options.UseNpgsql (Configuration.GetConnectionString ("DefaultConnection")));
      services.AddMvc(option => option.EnableEndpointRouting = false);
      services.AddIdentity<AppUser, IdentityRole> ()
        .AddEntityFrameworkStores<AppDbContext> ()
        .AddDefaultTokenProviders ();

      services.AddTransient<ICategoryRepository, CategoryRepository> ();
      services.AddTransient<IProductRepository, ProductRepository> ();
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor> ();
      services.AddScoped (sp => ShoppingCart.GetCart (sp));
      services.AddTransient<IOrderRepository, OrderRespository> ();

      services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_3_0);

      services.AddMemoryCache ();
      services.AddSession ();
      services.AddHttpContextAccessor();

      services.AddAuthentication (options => {
          options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie ();
      services.Configure<IdentityOptions>(options =>
      {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 4;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = false;
      });
      
    }

    public void Configure (IApplicationBuilder app, IHostEnvironment env) {
      if (env.IsDevelopment ()) {
        app.UseDeveloperExceptionPage ();
        app.UseDatabaseErrorPage ();
      } else {
        app.UseExceptionHandler ("/Home/Error");
        app.UseHsts ();
      }

      app.UsePathBase("/gs");
      app.UseSession ();
      app.UseHttpsRedirection ();
      app.UseStatusCodePages ();
      app.UseStaticFiles ();

      app.UseForwardedHeaders (new ForwardedHeadersOptions {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
      });

      app.UseAuthentication ();
      app.UseMvc (routes => {
        routes.MapRoute (
          name: "categoryFilter",
          template: "Product/{action}/{category?}",
          defaults : new { Controller = "Product", action = "List" });

        routes.MapRoute (
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
