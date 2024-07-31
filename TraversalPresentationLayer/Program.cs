using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddDbContext<Context>();

builder.Services.AddMvc(config=>
{
	var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireDigit = true;
	options.Password.RequiredLength = 8;
	options.Password.RequireUppercase = true; // En az bir büyük harf zorunluluðu
	options.Password.RequireLowercase = true; // En az bir küçük harf zorunluluðu
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequiredUniqueChars = 3;
});

builder.Services.AddMvc();

builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
{
    options.LoginPath = "/Login/SignIn";
});

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
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
