using EvDekorasyonu.Application;
using EvDekorasyonu.Application.Interfaces;
using EvDekorasyonu.Domain.Entities;
using EvDekorasyonu.MVC.Models;
using EvDekorasyonu.Persistence;
using EvDekorasyonu.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

await MigrateDatabase(app);

app.Run();


void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddApplicationServices(configuration);
    services.AddPersistenceServices(configuration);

    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

    services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

    services.ConfigureApplicationCookie(configure =>
    {
        configure.LoginPath = "/identity/login";
        configure.LogoutPath = "/identity/logout";

    });

    var urlViewModel = new LayoutUrlViewModel();

    urlViewModel.UrlViewModels.Add(new UrlViewModel
    {
        IconName = "dashboard",
        Text = "Dashboard",
        Url = "/admin/home/index"
    });

    urlViewModel.UrlViewModels.Add(new UrlViewModel
    {
        IconName = "table_view",
        Text = "Dekor",
        Url = "/admin/home/Dekor"
    });

    services.AddSingleton(urlViewModel);
}

async Task MigrateDatabase(IApplicationBuilder app)
{
    var scope = app.ApplicationServices.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (!context.Database.IsInMemory())
    {
        context.Database.EnsureCreated();
        context.Database.Migrate();
    }
    await AddSeedData(scope, context);
}


async Task AddSeedData(IServiceScope scope, ApplicationDbContext context)
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleExist = await roleManager.RoleExistsAsync("Admin");
    if (!roleExist)
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
        await roleManager.CreateAsync(new IdentityRole("User"));

    }

    if (!context.Users.Any())
    {
        var identityUser = new IdentityUser()
        {
            Email = "ece@ece.com",
            UserName = "ece",
        };
        var result = await userManager.CreateAsync(identityUser, "Ece@1234");
        if (result.Succeeded)
        {
            await userManager.AddToRolesAsync(identityUser, new[] { "Admin", "User" });
        }
    }

    var dekorService = scope.ServiceProvider.GetRequiredService<IDekorService>();
    var dekorCategoryService = scope.ServiceProvider.GetRequiredService<IDekorCategoryService>();
    if (!context.DekorCategories.Any())
    {
        var bibloCategory = await dekorCategoryService.InsertAsync(new DekorCategory()
        {
            Name = "Biblo Category",
            Description = "Biblo Category"
        });

        var ledCategory = await dekorCategoryService.InsertAsync(new DekorCategory()
        {
            Name = "Led Category",
            Description = "Led Category"
        });

        var mumCategory = await dekorCategoryService.InsertAsync(new DekorCategory()
        {
            Name = "Mum Category",
            Description = "Mum Category"
        });

        await dekorService.InsertManyAsync(new[]
        {
        new Dekor()
        {
            ImageUrl = "/images/recipes/1.jpg",
            Name = "Q-Art Model-262 6 Parça Çerçeveli Ahşap Tablo Seti",
            DekorCategoryId = bibloCategory.Id,
            Star = 1,
            IsActive = false
        },
        new Dekor()
        {
            ImageUrl = "/images/recipes/2.jpg",
            Name = "Kişisel Oda Dekorasyonu",
            DekorCategoryId = ledCategory.Id,
            Star = 4
        },
        new Dekor()
        {
            ImageUrl = "/images/recipes/3.jpg",
            Name = "Ahşep Desenli Saat Dekorasyonu",
            DekorCategoryId = mumCategory.Id,
            Star = 4,
            IsActive = false
        },
        new Dekor()
        {
            ImageUrl = "/images/recipes/4.jpg",
            Name = "IKEA Cam Mum Dekorasyonu",
            DekorCategoryId = bibloCategory.Id,
            Star = 2
        },
        new Dekor()
        {
            ImageUrl = "/images/recipes/5.jpg",
            Name = "Çiçekli Saat Dekorasyonu",
            DekorCategoryId = ledCategory.Id,
            Star = 2,
            IsActive = false
        },
        new Dekor()
        {
            ImageUrl = "/images/recipes/6.jpg",
            Name = "Ahşap Üstündeki Muazzam",
            DekorCategoryId = mumCategory.Id,
            Star = 2
        },
        new Dekor()
        {
            ImageUrl = "/images/recipes/7.jpg",
            Name = "Buzlu Cam Vazo",
            DekorCategoryId = bibloCategory.Id,
            Star = 2
        },
        new Dekor()
        {
            ImageUrl = "/images/recipes/8.jpg",
            Name = "Kapı Onu Hayali Posta Kutusu",
            DekorCategoryId = ledCategory.Id,
            Star = 2
        },
        new Dekor()
        {
            ImageUrl = "/images/recipes/9.jpg",
            Name = "Mantar Mum Dekorasyonu",
            DekorCategoryId = mumCategory.Id,
            Star = 2
        }
    });
    }
  
}
