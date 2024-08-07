using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;
using TraversalPresentationLayer.CQRS.Handlers.DestinationHandlers;
using TraversalPresentationLayer.Mapping.AutoMapperProfile;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.AddFile($"{Directory.GetCurrentDirectory()}\\LogFile\\log.txt", LogLevel.Error);

});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddDbContext<Context>();

builder.Services.AddHttpClient();

//CQRS Mimarisinin Scope'larý
builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationByIDQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<DeleteDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();

builder.Services.AddMediatR(typeof(Program)); //MediatR'ý kullanabilme parametresi.

Extensions.ContainerDependencies(builder.Services);

builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);

Extensions.CustomValidator(builder.Services);

builder.Services.AddControllersWithViews().AddFluentValidation();

builder.Services.AddMvc(config =>
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

app.UseStatusCodePagesWithReExecute("/Error/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
