using DMTools.Blazor.Components;
using Microsoft.EntityFrameworkCore;
using DMTools.Database;
using DMTools.Security;
using Carter;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Components.Authorization;
using DMTools.Blazor;

var builder = WebApplication.CreateBuilder(args);

string cookieBaseName = builder.Environment.ApplicationName.Replace(" ", "");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCarter();

builder.Services.AddScoped<AuthenticationStateProvider,
    DmToolsAuthenticationStateProvider>();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt => {
    opt.Cookie.Name = $"{cookieBaseName}.Session";
    opt.IdleTimeout = TimeSpan.FromHours(1);
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
});
builder.Services.AddAntiforgery(opt =>
    opt.Cookie.Name = $"{cookieBaseName}.AntiForgery");

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDbContext<DmtoolsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAuthenticator, Authenticator>();
builder.Services.AddScoped<IUserFunctions, UserFunctions>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapCarter();

app.Run();
