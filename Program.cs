using _Net_Core_IdentityServer4;
using _Net_Core_IdentityServer4.Data;
using _Net_Core_IdentityServer4.Data.Entities;
using _Net_Core_IdentityServer4.Services;
using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.UserInteraction.LoginUrl = "/Login";
    options.UserInteraction.LogoutUrl = "/SignOut";
    options.UserInteraction.LogoutIdParameter = "SignOutId";
})
.AddInMemoryApiResources(Config.GetApiResources)
              .AddInMemoryIdentityResources(Config.GetIdentityResources)
              .AddInMemoryApiScopes(Config.GetApiScopes)
              .AddInMemoryClients(Config.GetClients)
              .AddAspNetIdentity<User>()
              .AddDeveloperSigningCredential()
              .AddProfileService<ProfileService>();

builder.Services.AddAuthentication()
    .AddFacebook(options =>
    {
        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
        options.ClientId = "copy client ID from Facebook here";
        options.ClientSecret = "copy client secret from Facebook here";
    })
    .AddGoogle(options =>
    {
        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
        options.ClientId = "copy client ID from Google here";
        options.ClientSecret = "copy client secret from Google here";
    });


builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IProfileService, ProfileService>();



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
app.UseRequestLocalization();

app.UseAuthentication();
app.UseAuthorization();

app.UseIdentityServer();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

