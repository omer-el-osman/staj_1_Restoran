using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyClasses;
using MyData;
using MyData.repo;
using Restoran.Data;
using Restoran.E_Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("User", op => op.RequireClaim("User"));
    op.AddPolicy("Admin", op => op.RequireClaim("Admin"));
}

);




builder.Services.AddTransient<Ihelper<Kullanici>,KullaniciEntity>();
builder.Services.AddTransient<Ihelper<Subeler>,SubelerEntity>();
builder.Services.AddTransient<Ihelper<yemekKatigorisi>,yemekKatigorisiEntity>();
builder.Services.AddTransient<Ihelper<yemekMenusu>,yemekMenusuEntity>();
builder.Services.AddTransient<Ihelper<AnaSayfaMessajleri>,AnaSayfaMessajleriEntity>();
builder.Services.AddTransient<Ihelper<Masalar>,MasalarEntity>();
builder.Services.AddTransient<Ihelper<Order>,OrderEntity>();
builder.Services.AddTransient<Ihelper<Reservasyon>,ReservasyonEntity>();





builder.Services.AddTransient<IEmailSender, Email_Onaylama>();




var app = builder.Build();






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(Endpoints =>
{
   
    Endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    Endpoints.MapRazorPages();
});
app.Run();
