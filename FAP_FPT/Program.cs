using FAP_FPT.Business.IRepository;
using FAP_FPT.Business.Mapping;
using FAP_FPT.Business.Repository;
using FAP_FPT.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/login", "");
});

builder.Services.AddCors();

builder.Services.AddTransient<IUserRepository, UserRepository>()
    .AddDbContext<FAP_FPTContext>(
        otp =>
            builder.Configuration.GetConnectionString("ConnectString"));

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddSession();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultSignInScheme = "CookieScheme";
        options.DefaultChallengeScheme = "GoogleScheme";
    })
    .AddCookie("CookieScheme")
    .AddGoogle(
        "Google", options =>
        {
            IConfiguration googleAuthen = builder.Configuration.GetSection("Authentication:Google");
            options.SaveTokens = true;
            options.ClientId = "438975213439-i2q8emg7slpcu7dqhamuc2nv11oiosb4.apps.googleusercontent.com";
            options.ClientSecret = "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";
            options.CorrelationCookie.SameSite = SameSiteMode.Lax;
        }
    );

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.UseSession();

app.UseCookiePolicy();
 
app.Run();
