﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ney_Nemovitost.web.Models.ApplicationServices.Abstraction;
using Ney_Nemovitost.web.Models.ApplicationServices.Implementation;
using Ney_Nemovitost.web.Models.Database;
using Ney_Nemovitost.web.Models.Identity;
using System.Text;

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
        services.AddDbContext<NemovitostDBContext>(options => options.UseMySql(Configuration.GetConnectionString("MySqlConnectionString"), new MySqlServerVersion("8.0.26")));

        services.AddIdentity<User, Role>()
        .AddEntityFrameworkStores<NemovitostDBContext>()
        .AddDefaultTokenProviders();


        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequiredUniqueChars = 1;

            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.MaxFailedAccessAttempts = 10;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);

            options.User.RequireUniqueEmail = false;
        });

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromDays(30);
            options.LoginPath = "/Security/Account/Login";
            options.LogoutPath = "/Security/Account/Logout";
            options.SlidingExpiration = true;
        });
        services.AddScoped<ISecurityApplicationService, SecurityIdentityApplicationService>();
        services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
        services.AddSession(options =>
        {
            // Set a short timeout for easy testing.
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            // Make the session cookie essential
            options.Cookie.IsEssential = true;
        });

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
        System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
        Encoding.RegisterProvider(ppp);
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
              );
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}